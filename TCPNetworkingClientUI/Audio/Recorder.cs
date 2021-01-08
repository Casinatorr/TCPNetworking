using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace TCPNetworkingClientUI.Audio
{
    public class Recorder
    {
        private WaveIn recorder;
        private Packet recording;

        private bool isRecording;
        private Encoder encoder;

        private DateTime startRecording;
        private static int maxRecordingTime = 15000;

        public void StartRecording()
        {
            recorder = new WaveIn();
            recorder.WaveFormat = new WaveFormat();
            recorder.DataAvailable += onDataAvailable;


            isRecording = true;
            recording = new Packet();
            startRecording = DateTime.Now;
            recorder.StartRecording();
            encoder = new Encoder();
        }

        private void onDataAvailable(object sender, WaveInEventArgs e)
        {
            recording.Write(e.Buffer);
            if (DateTime.Now.Subtract(startRecording).TotalMilliseconds >= maxRecordingTime)
                ChatUI.instance.Record(null, null);
        }

        public Packet StopRecording()
        {
            if (!isRecording)
                return new Packet();

            recorder.StopRecording();
            byte[] data = recording.ReadBytes(recording.Length());
            Console.WriteLine(data.Length);
            data = encoder.Encode(data, 0, data.Length);
            Console.WriteLine(data.Length);
            recording.Reset(true);
            recording.SetBytes(data);
            return recording;
        }
    }
}

