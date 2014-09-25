The actual Synth
=============

This Arduino based project emulates a SID sound chip (MOS6581) and uses it to create a polyphonic syntesizer controllable in MIDI over USB. There is a plan for a second iteration in which an actual SID is used.

The current output quality is not great, after all I have used just an 8 ohm speaker directly connected to a digital pin, so some distortion is expected. A low pass filter and an amplifier to drive the speaker would surely make things better. I was more interested in the code anyhow than designing the rest of the hardware, for now.

![Proto](Documentation/proto.jpg)

I made use of the SID emulator library: https://code.google.com/p/sid-arduino-lib/ and of the MIDI library: http://playground.arduino.cc/Main/MIDILibrary

The current implementation makes use of MIDI channel 1 and supports up to 3 voices, as this is the amount of generators available in the SID. The following MIDI messages are processed: Note On, Note Off, Control Change (limited to Legato and Damper foot switch), all other messages are ignored.

Folder SIDMIDISynth contains the Arduino code.

This video shows an early version of the prototype in action: http://youtu.be/jMqI9DxzDNc the out of tune sound was mainly due to innacurate MIDI note frequency conversions.

##MIDI Messages

The following sections describe how each supported MIDI message is processed and how that affects the synthetizer operation.

###Note On

The Note On message contains two parameters the pitch of the note and the the velocity. Velocity in MIDI refers to the strength of the key hit. When a Note On message is received first of all we look for a voice that is not playing any note, if one is found then the pitch of that note is assigned to that voice. The envelope generator sustain level is set to a value proprtional with the note velocity, which provides relative notes amplitude scaling. The attack and decay are both set to zero as, otherwise, the note would always peak to maximum before reaching the sustain level. The release rate is not set here and depends on the last status of other MIDI messages. When all is setup the gate for the voice is finally set.

In MIDI it's possible to have Note On messages with a velocity zero, these are treated as Note Off.

###Note Off

The Note Off message indicates that the note is to be released. When a Note Off is received we first find which is the voice that is playing that note pitch and set the gate for that voice off. At this point the release cycle begins. One shortcome in the current implementation is that the voice is marked as free immediately following a Note Off, so if the damper pedal is pressed (enabling a long release time) the voice might get reused before the release cycle is over.

###Control Change

Of the Control Change message we process on the Legato Footswitch and the Damper Pedal control messages. If the Legato Footswitch is depressed we simply don't gate off the voice anymore when it becomes free (Note Off) but do so only when the next note is about to be set on that voice. If the Damper Pedal is depressed then we set the decay time of the envelope generator to a rather large value (9 seconds).

Serial MIDI Sequencer
=============

The serial MIDI sequencer is pretty much a test tool for the SID MIDI Synth. It takes any MIDI file and sequences it through a selected serial port. It currently routes all MIDI messages to MIDI channel 1, so it's not suitable to actually control multiple instruments. Also only Note On, Note Off and Control Change messages are processed at the moment. The application remembers the last played file and it's possible to set it to aumatically start play on start which saves time when going through tests.

![Screenshot](Documentation/MIDIStreamer.png)



SID Controller
=============

This application offers a GUI to control every sigle SID register. Each register change is sent over the MIDI interface as a System Exclusive message. Below is the screenshot for the control panel of one of the voices.


![Controller](Documentation/ControllerScreenshot.png)
