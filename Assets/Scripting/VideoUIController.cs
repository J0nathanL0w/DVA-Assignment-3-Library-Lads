using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

/*
 1. Create the RawImage for Video Display
In your Canvas, right-click → UI → Raw Image → name it VideoDisplay.

Resize it to the area you want the video to show.

This RawImage will display whatever texture the video is rendering to.

2. Create a Render Texture
In the Project window, right-click → Create → Render Texture.

Name it VideoTexture.

This is basically a “screen” for the video to draw on.

3. Configure the VideoPlayer
On your VideoController GameObject:

Render Mode → Render Texture.

Assign the VideoTexture you created to Target Texture.

Play On Awake → OFF (important so it doesn’t start playing immediately).

Assign your video file to the Video Clip field.

Now, go to your VideoDisplay (RawImage) and assign the same VideoTexture to its Texture field.

5. Final Wiring
Video Player → drag from VideoController into the script slot.

Start Button, Stop Button, Progress Slider → drag your UI elements.

Make sure Video Clip is assigned in VideoPlayer.

Ensure RawImage (VideoDisplay) has the Render Texture assigned as its texture.
 */


public class VideoUIController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Button startButton;
    public Button stopButton;
    public Slider progressSlider;

    private bool isDraggingSlider = false;

    void Start()
    {
        startButton.onClick.AddListener(OnPlayButton);
        stopButton.onClick.AddListener(StopVideo);

        progressSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Disable autoplay
        videoPlayer.playOnAwake = false;
    }

    void Update()
    {
        if (videoPlayer.isPlaying && !isDraggingSlider && videoPlayer.length > 0)
        {
            progressSlider.value = (float)(videoPlayer.time / videoPlayer.length);
        }
    }

    void OnPlayButton()
    {
        // Resume from current slider position instead of restarting
        double targetTime = progressSlider.value * videoPlayer.length;
        videoPlayer.time = targetTime;
        videoPlayer.Play();
    }

    void StopVideo()
    {
        videoPlayer.Pause(); // Use Pause instead of Stop to keep current position
    }

    void OnSliderValueChanged(float value)
    {
        if (isDraggingSlider)
        {
            double newTime = value * videoPlayer.length;
            videoPlayer.time = newTime;
        }
    }

    public void OnBeginDragSlider()
    {
        isDraggingSlider = true;
    }

    public void OnEndDragSlider()
    {
        isDraggingSlider = false;
        double newTime = progressSlider.value * videoPlayer.length;
        videoPlayer.time = newTime;

        // If paused, update frame after seeking
        if (!videoPlayer.isPlaying)
            videoPlayer.Play(); // Uncomment if you want it to auto-play after dragging
    }

}
