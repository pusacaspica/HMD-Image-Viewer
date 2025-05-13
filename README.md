This is a slideshow for a very specific goal: comparing pre-rendered pairs of images in a random order. I believe it works if you build it as is, but it is safer to run it within Unity (that's how I ran it every time). This is not that elegant since it was really done for personal use, but I can work on it if there is demand for upgrading the user experience!

To load your own images:
 - put your images on the Resources folder
 - set the prefix variables on the SlideController script within Unity
 - set the slideshow parameters (such as time in seconds for each image and time between images) at the TestRoutineController script within Unity
 - (the scripts can be found at the Plane within the SampleScene)
![image](https://github.com/user-attachments/assets/899229cb-c147-4a92-8e18-26cedb72451c)

While running, controls are: 
 - S for starting the random passing of each pair
 - F changes the image of the pair
 - 1-9 switches between images 1 to 9 (the slideshow should behave if you put more images)
 - arrow keys for passing between images

These images were used on user experiments of a couple of works, developed during my Master's Degree (hey I'm a master now!) and at the very beginning of my PhD:
 - Henriques, Horácio, et al. "A mixed path tracing and NeRF approach for optimizing rendering in XR Displays." Simpósio de Realidade Virtual e Aumentada (SVR). SBC, 2023.
 - Henriques, Horácio, et al. "Foveated Path Culling: A mixed path tracing and radiance field approach for optimizing rendering in XR Displays." Journal on Interactive Systems 15.1 (2024): 576-590.
 - Henriques, Horácio, et al. "Analysing Hybrid Neural and Ray Tracing Perception for Foveated Rendering." Simpósio de Realidade Virtual e Aumentada (SVR). SBC, 2024.

And, very soon, if everything works out
 - Henriques, Horácio, et al. "Comparing Perceptual Visual Quality of Hybrid Neural and Ray Tracing in Foveated Rendering." Journal on Interactive Systems 16.1 (2025).

Last, but not least, huge thanks to :
 - José Machado (jcamachado@id.uff.br) for making me update this repository and writing a proper readme.md,
 - Esteban Clua for the orientation throughout the years,
 - to all my co-authors, that totally rocks and were massively important for the publications that we got until now
 - to the editorial board of the Journal of Interactive Systems for reminding me that I should have made this repository public ages ago.
