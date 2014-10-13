# DSP.RainDetector



This project contains all the algorithms doing rain detection. It contains one or more implementation of the main service (IRainDetectionService) which are detailed below.


## DefaultRainDetectionService

This implementation does the original raindrop detection using Canny edge detection to make raindrops clearly visible.
The main steps are:

 * Preprocessing image finishing with Canny edge detection.
 * Detecting raindrop areas with blob detection implemented by AForge.
 * Filtering areas.
 * Counting areas.