using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Sony.Vegas;
using System.Collections.Generic;

namespace ExportVegasData
{
    public partial class ScriptForm : Form
    {
        public Vegas vegas;
        private ProjectData projectData;
        private int numberOfVideos;
        private int numberOfAudios;


        public ScriptForm(Vegas vegas)
        {
            this.vegas = vegas;
            InitializeComponent();
            richTextBox.Text = "Было экспортировано:\n...";
        }

        private void ExportData(object sender, EventArgs e)
        {
            numberOfVideos = numberOfAudios = 0;

            projectData = new ProjectData();
            SetProjectData();
            OpenSaveFileDialog();
        }

        private void OpenSaveFileDialog ()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog.FileName = "Vegas data.json";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "json files (*.json) | *.json";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = Path.Combine(saveFileDialog.InitialDirectory, saveFileDialog.FileName);
                string obj = JsonConvert.SerializeObject(projectData, Formatting.Indented);

                try
                {
                    File.WriteAllText(filepath, obj);
                    richTextBox.Text = $"Было экспортировано:\n{numberOfVideos} Видео клипов\n{numberOfAudios} Аудио клипов";
                }
                catch (Exception ex)
                {
                    richTextBox.Text = ex.ToString();
                }
            }
        }

        private void SetProjectData ()
        {
            projectData.ProjectName = Path.GetFileName(vegas.Project.FilePath);
            projectData.FilePath = vegas.Project.FilePath;
            projectData.Width = vegas.Project.Video.Width;
            projectData.Height = vegas.Project.Video.Height;
            projectData.PixelAspectRatio = vegas.Project.Video.PixelAspectRatio;
            projectData.FrameRate = vegas.Project.Video.FrameRate;
            projectData.Length = vegas.Project.Length.ToString();
            projectData.Tracks = GetTracks(vegas.Project.Tracks);
        }

        private List<ExportTrack> GetTracks(Tracks vegasTracks)
        {
            List<ExportTrack> tracks = new List<ExportTrack>();
            foreach (Track track in vegasTracks)
            {

                if (!exportVideoCheckBox.Checked & track.MediaType == MediaType.Video)
                {
                    continue;
                }

                if (!exportAudioCheckBox.Checked & track.MediaType == MediaType.Audio)
                {
                    continue;
                }

                tracks.Add(new ExportTrack( 
                    track.Name,
                    track.MediaType.ToString(),
                    GetTrackElements(track)
                    ));
            }
            return tracks;
        }
        
        private List<MediaElement> GetTrackElements (Track track)
        {
            List<MediaElement> mediaElements = new List<MediaElement>();
            foreach (TrackEvent element in track.Events)
            {
                MediaElement mediaElement = new MediaElement();
                if (element.MediaType == MediaType.Video && element.Selected)
                {
                    mediaElement = new Video();
                    ((Video)mediaElement).Velocity = GetVelocity((VideoEvent)element);
                    numberOfVideos++;
                }
                else if (element.Selected)
                {
                    mediaElement = new Audio();
                    ((Audio)mediaElement).Volume = Math.Round(element.FadeIn.Gain, 4) * 100;
                    numberOfAudios++;
                }

                SetMeiadData(mediaElement, element);
                mediaElements.Add(mediaElement);
            }
            return mediaElements;
        }

        private Velocity GetVelocity(VideoEvent vegasVideo)
        {
            Velocity velocity = new Velocity(GetVelocityPoints(vegasVideo));
            return velocity;
        }

        private List<VelocityPoint> GetVelocityPoints(VideoEvent vegasVideo)
        {
            List<VelocityPoint> velocityPoints = new List<VelocityPoint>();

            foreach (Envelope envelope in vegasVideo.Envelopes)
            {
                if (envelope.Type == EnvelopeType.Velocity & envelope.Points.Count != 0)
                {
                    foreach (EnvelopePoint point in envelope.Points)
                    {
                        velocityPoints.Add(new VelocityPoint(point.X.ToString(), point.Y));
                    }
                }
            }

            if (velocityPoints.Count == 0)
            {
                velocityPoints = null;
            }
            return velocityPoints;
        }

        private void SetMeiadData(MediaElement mediaElement, TrackEvent element)
        {
            mediaElement.Name = element.ActiveTake.Name;
            mediaElement.FilePath = element.ActiveTake.MediaPath;
            mediaElement.Start = element.Start.ToString();
            mediaElement.Length = element.Length.ToString();
        }
    }

    public class EntryPoint
    {
        private static ScriptForm scriptForm;

        public void FromVegas(Vegas vegas)
        {
            scriptForm = new ScriptForm(vegas);
            scriptForm.ShowDialog();
        }
    }

}
