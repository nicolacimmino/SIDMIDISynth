// SIDMIDISynth implements a MIDI controllable synthetizer based on an emulated SID.
//  Copyright (C) 2014 Nicola Cimmino
//
//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//   This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program.  If not, see http://www.gnu.org/licenses/.
//

// We make use of the MIDI library (http://arduinomidilib.sourceforge.net)
#include <MIDI.h>
#include <midi_Defs.h>
#include <midi_Message.h>
#include <midi_Namespace.h>
#include <midi_Settings.h>

// We make use of SID emulator (http://code.google.com/p/sid-arduino-lib/)
#include <SID.h>

#define DUMPER_PEDAL_LED A0
#define LEGATO_FOOTSWITCH_LED A1
#define VOICE1_GATE_LED A5
#define VOICE2_GATE_LED A4
#define VOICE3_GATE_LED A3

byte voice_gate_leds[] = { VOICE1_GATE_LED, VOICE2_GATE_LED, VOICE3_GATE_LED };

// Creates an instance of the MIDI controller.
MIDI_CREATE_DEFAULT_INSTANCE();

// The SID emulator
SID sid;

// Amount of voices in this synthetizer
#define VOICES_COUNT 3

// MIDI channel on which we receive commands.
#define MIDI_CHANNEL 1

// The currently playing note in each of the voices.
byte voiceNotes[VOICES_COUNT] = { 0, 0, 0 };

byte sidRegistersBase[VOICES_COUNT] = {VOICE1, VOICE2, VOICE3};

bool legato=false;

void setup()
{
  sid.begin();
  
  // We act as a single polyphonic channel. So we make use of all 3 voices.
  // We don't handle instrument change commands, so we just set here some default
  // envelope generator settings that are supposed to sound like a piano.
  for(byte v=0; v<VOICES_COUNT; v++)
  {
    sid.set_register(sidRegistersBase[v]+PULSEWIDTHREG,0x08); // 50% pulse width, in case we use pulse
    sid.set_register(sidRegistersBase[v]+ATTACKDECAY,0x00);   // A=0 D=9
    sid.set_register(sidRegistersBase[v]+SUSTAINRELEASE,0xF0); // S=0 R=0. S level will be set according to MIDI velocity.
    sid.set_register(sidRegistersBase[v]+4, 16); // Triiangle
  }
  sid.set_register(VOLUME,15);
  
  // Register callbacks for MIDI events.
  MIDI.setHandleNoteOn(handleNoteOn);
  MIDI.setHandleNoteOff(handleNoteOff);
  MIDI.setHandleSystemExclusive(handleSystemExclusive);
  MIDI.setHandleControlChange(handleControlChange);
  MIDI.begin();
  
  pinMode(DUMPER_PEDAL_LED, OUTPUT);
  digitalWrite(DUMPER_PEDAL_LED, LOW);

  pinMode(LEGATO_FOOTSWITCH_LED, OUTPUT);
  digitalWrite(LEGATO_FOOTSWITCH_LED, LOW);
  
  for(int v=0; v<VOICES_COUNT; v++)
  {
    pinMode(voice_gate_leds[v], OUTPUT);
    digitalWrite(voice_gate_leds[v], LOW);
  }
}

// This will be invoked by the MIDI library every time we receive
//  a NoteOn command.
//
void handleNoteOn(byte inChannel, byte inNote, byte inVelocity)
{
  if(inChannel != MIDI_CHANNEL)
  {
    return;
  }
  
  // Alternate mode in MIDI to give noteoff is to pass the note with velocity zero.
  if(inVelocity==0)
  {
    handleNoteOff(inChannel, inNote, inVelocity); 
    return; 
  }
  
  // Find a free voice to play this note
  byte voice=VOICES_COUNT;
  for(int v=0; v<VOICES_COUNT; v++)
  {
    if(voiceNotes[v]==0)
    {
      voice = v;
      break;
    }
  }
  
  // We run out of voices, ignore note on command
  if(voice==VOICES_COUNT)
  {
    return;
  }
  
  if(legato)
  {
    sid.set_register(sidRegistersBase[voice]+4,sid.get_register(sidRegistersBase[voice]+4)&0xFE);
  }
  
  // We first convert the MIDI note to a frequency and then that
  //  to the suitable SID registers value.
  double frequency = getNoteFrequency(inNote);
  int sidFrequency = 17.028408 * frequency; 
  sid.set_register(sidRegistersBase[voice]+FREQUENCYL,(sidFrequency>>8)&0xFF);
  sid.set_register(sidRegistersBase[voice]+FREQUENCYH,sidFrequency&0xFF);
  
  // Velocity, which in MIDI is from 0 to 127 is mapped to the Sustain Rate of the ADSR envelope (0-15)
  sid.set_register(sidRegistersBase[voice]+SUSTAINRELEASE,0+((inVelocity>>3)<<4));
  
  // Gate the geneator
  sid.set_register(sidRegistersBase[voice]+4,sid.get_register(sidRegistersBase[voice]+4)|0x01);
  
  // Store the note that is being played in this voice.
  voiceNotes[voice] = inNote;
  
  digitalWrite(voice_gate_leds[voice], HIGH);
}

// This will be invoked by the MIDI library every time we receive
//  a NoteOff command.
//
void handleNoteOff(byte inChannel, byte inNote, byte inVelocity)
{ 
  if(inChannel != MIDI_CHANNEL)
  {
    return;
  }
  
  // Find the voice that is playing this note
  byte voice=VOICES_COUNT;
  for(int v=0; v<VOICES_COUNT; v++)
  {
    if(voiceNotes[v]==inNote)
    {
      voice = v;
      break;
    }
  }
  
  // No voice is playing this note.
  if(voice==VOICES_COUNT)
  {
    return;
  }
  
  // Gate off the generator, this will start the release phase and then put the voice off.
  if(!legato)
  {
    sid.set_register(sidRegistersBase[voice]+4,sid.get_register(sidRegistersBase[voice]+4)&0xFE); 
  }
  
  // The voice is now free.
  voiceNotes[voice] = 0;
  
  digitalWrite(voice_gate_leds[voice], LOW);
}

// This will be invoked by the MIDI library every time we receive
//  a System Exclusive command.
//
void handleSystemExclusive(byte* array, unsigned int dataSize)
{
  // We checke first of all manufacturer ID. These are actually assigned
  // by NMA and AMEI, so for the purpose of this demo I just made up my own.
  // The second byte is the command, I just made up here 0x01 to be a
  // "register write" command to allow direct SID registers manipulation.
  if(array[1]==0x3B && array[2]==0x01)
  {
    sid.set_register(array[3],array[4]);
  }
}

void handleControlChange(byte channel, byte number, byte value)
{
  // Legato footswitch 
  if(number==0x44)
  {
    legato=(value>=64);
    digitalWrite(LEGATO_FOOTSWITCH_LED,legato?HIGH:LOW);
  }
  
  // Damper pedal. 
  // When actioned this pedal, in a piano, prevents dampers from stopping the
  // vibration of the strings when the key is released. We model this with
  // a longer release so when we gate off the voice for a note off event
  // the note keeps playing its tail.
  // This is not like in real life as the limited amount of voices means if
  // another note on comes we will start playing the new note. It's the closest
  // we can get with only 3 voices.
  if(number==0x40)
  {
    for(byte v=0; v<VOICES_COUNT; v++)
    {
      sid.set_register(sidRegistersBase[v]+SUSTAINRELEASE,(value>=64)?0xFC:0xF0); // S=0 R=0 or 9 if dumper pedal depressed
      digitalWrite(DUMPER_PEDAL_LED,(value>=64)?HIGH:LOW);
    }  
  }
}

void loop()
{
  // Process next MIDI command if any.
  MIDI.read();
}

// This is a table used to convert MIDI notes numbers to frequency.
// This is the first octave (notes 0 to 11). The following octaves
// can be calculated.
double note_freq_lookup[] = {
 8.1757989156,
 8.6619572180, 
 9.1770239974, 
 9.7227182413, 
 10.3008611535, 
 10.9133822323, 
 11.5623257097, 
 12.2498573744, 
 12.9782717994, 
 13.7500000000, 
 14.5676175474,
 15.4338531643 };

// Gets the frequency, in Hz, of a note given the MIDI note number.
double getNoteFrequency(byte note)
{
  int octave=floor(((double)(note))/12.0f);
  return note_freq_lookup[note-(12*octave)]*pow(2,octave); 
}

 
