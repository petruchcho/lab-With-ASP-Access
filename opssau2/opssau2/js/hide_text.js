function displ(containerId, linkId, hideId) { 
	if (document.getElementById(containerId).style.display == 'none') {
		document.getElementById(containerId).style.display = 'block';
		document.getElementById(linkId).style.display = 'none';
	} else {
		document.getElementById(containerId).style.display = 'none'
	} 
	document.getElementById(hideId).style.display = 'block'
}

function hide(containerId, linkId, hideId) { 
	if (document.getElementById(containerId).style.display == 'none') {
		document.getElementById(containerId).style.display = 'block';
	} else {
		document.getElementById(containerId).style.display = 'none'
	} 
	document.getElementById(linkId).style.display = 'block';
	document.getElementById(hideId).style.display = 'none'
}