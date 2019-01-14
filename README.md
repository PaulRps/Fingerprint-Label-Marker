# FingerprintLabelMarker
Application to generate ground truth of singularities from fingerprint images. There are three possible class to mark:

* Core - this class represents the point where fingerprint core lies (inner most minutiae end);

* Delta - this class represents the point where three ridges meet;

* Neg - this class is not a Core neither a Delta, it is none.

The three classes are represented by 3 colors: blue, green and red, respectively.


# Features

* Load your fingerprint image dataset.

* Save the marked labels as image (50x50 and .bmp) and text (coordinates x, y and the singularity type).

* Restart at the image where you stopped by loading the saved txt file.

* See the current image that you just marked.

* Undo last marked label.

* Reset all marked label of a image.


# How to work

* Click on menu option 'Load Dataset' and choose the folder where are the fingerprint images - it loads all images name on screen.

* Select a image and mark the labels as you wish - you have to click on mouse buttons: left = Core; middle = Delta; right = Neg. There are subtitles on screen that explains the selected box colors.

* Save the marked labels by clicking on menu option 'Save Ground Truth' - it generates a folder with a txt file (text info) and folders with the images separeted by class.

* You can restart at the point where you stopped at last time, you have to click on menu option 'Load Checkpoint File' and choose the saved txt file.

* You can undo the last marked label by clicking on 'Undo' buttom on screen.

* You can reset all marked labels of a image by clicking on 'Reset' buttom on screen - it removes all labels of the selected image.
