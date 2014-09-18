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

// Creates an instance of the MIDI controller.
MIDI_CREATE_DEFAULT_INSTANCE();

// The SID emulator
SID sid;

// Amount of voices in this synthetizer
#define VOICES_COUNT 3

// MIDI channel on which we receive commands.
#define MIDI_CHANNEL 0

// The currently playing note in each of the voices.
byte voiceNotes[VOICES_COUNT] = { 0xFF, 0xFF, 0xFF };

byte sidRegistersBase[VOICES_COUNT] = {VOICE1, VOICE2, VOICE3};

void setup()
{
  sid.begin();
  
  // We act as a single polyphonic channel. So we make use of all 3 voices.
  // We don't handle instrument change commands, so we just set here some default
  // envelope generator settings.
  for(byte v=0; v<VOICES_COUNT; v++)
  {
    sid.set_register(sidRegistersBase[v]+ATTACKDECAY,9);
    sid.set_register(sidRegistersBase[v]+SUSTAINRELEASE,0);
  }
  sid.set_register(VOLUME,15);
  
  // Register callbacks for MIDI events.
  MIDI.setHandleNoteOn(handleNoteOn);
  MIDI.setHandleNoteOff(handleNoteOff);
  MIDI.begin();
    
}

// This will be invoked by the MIDI library every time we receive
//  a NoteOn command.
//
void handleNoteOn(byte inChannel, byte inNote, byte inVelocity)
{
  if(channel != MIDI_CHANNEL)
  {
    return;
  }
  
  // Find a free voice to play this note
  byte voice=0xFF;
  for(int v=0; v<3; v++)
  {
    if(voiceNotes[voice]==0xFF)
    {
      voice = v;
      break;
    }
  }
  
  // We run out of voices, ignore note on command
  if(voice==0xFF)
  {
    return;
  }
  
  // We first convert the MIDI note to a frequency and then that
  //  to the suitable SID registers value.
  int frequency = getNoteFrequency(inNote);
  int sidFrequency = 17 * frequency; 
  sid.set_register(sidRegistersBase[voice]+FREQUENCYH,sidFrequency>>8);
  sid.set_register(sidRegistersBase[voice]+FREQUENCYL,sidFrequency&0xFF);
  
  // We just gate the note now with a sawtooth for now. We ignore the velocity
  // (needs to be set in the ADSR envelope as S lavel).
  sid.set_register(sidRegistersBase[voice]+4,33);
     
  // Store the note that is being played in this voice.
  voiceNotes[voice] = inNote;
}

// This will be invoked by the MIDI library every time we receive
//  a NoteOff command.
//
void handleNoteOff(byte inChannel, byte inNote, byte inVelocity)
{ 
  if(channel != MIDI_CHANNEL)
  {
    return;
  }
  
  // Find the voice that is playing this note
  byte voice=0xFF;
  for(int v=0; v<3; v++)
  {
    if(voiceNotes[voice]==inNote)
    {
      voice = v;
      break;
    }
  }
  
  // No voice is playing this note.
  if(voice==0xFF)
  {
    return;
  }
  
  // Gate off the voice.
  sid.set_register(voiceNotes[voice]+4,32);
  
  // The voice is now free.
  voiceNotes[voice] = 0xFF;
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
  int octave=floor(note/12);
  return note_freq_lookup[note%12]*pow(2,octave);  
}

 
