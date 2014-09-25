
Serial MIDI Sequencer
=============

The serial MIDI sequencer is pretty much a test tool for the SID MIDI Synth. It takes any MIDI file and sequences it through a selected serial port. It currently routes all MIDI messages to MIDI channel 1, so it's not suitable to actually control multiple instruments. Also only Note On, Note Off and Control Change messages are processed at the moment. The application remembers the last played file and it's possible to set it to aumatically start play on start which saves time when going through tests.

![Screenshot](Documentation/MIDIStreamer.png)



SID Controller
=============

This application offers a GUI to control every sigle SID register. Each register change is sent over the MIDI interface as a System Exclusive message. Below is the screenshot for the control panel of one of the voices. This is also a test application and it's development to a polished application is out of the scope of this project. You will need to adjust source code to match your serial port configuration.

![Controller](Documentation/ControllerScreenshot.png)

SID File Streamer
============

This is also a test application. It takes dumps generared by SidDump (http://csdb.dk/release/?id=18501&show=notes#notes) and sends every register change as a MIDI System Exclusive message. This allows to test more complex SID sounds than just single notes from a MIDI file. This application also will not be polished as part of this project, you will need to modify the source to point to your relevant dump file and serial port.

