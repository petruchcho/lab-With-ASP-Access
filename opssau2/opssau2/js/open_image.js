function openSrc(imageSrc) { 
	window.open(imageSrc, "image");
}

function resizeImage(imageId, width, height) {
	document.getElementById(imageId).width = width;
	document.getElementById(imageId).height = height;
}