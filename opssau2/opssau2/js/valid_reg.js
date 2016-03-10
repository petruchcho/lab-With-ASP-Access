function count_rabbits() {
    alert("Из шляпы достали кролика!")
}


function showError(container) {
	console.log('show error');
 	container.className += " error";
}

function resetError(container) {
  container.className = container.className.replace(' error', '');
}

function validateForm(form, checkEmpty) {
	var elems = form.elements;
	console.log('validate form');

    var result = true;

	result &= validateIsEmpty(elems.login_field, checkEmpty);
	
	result &= validateName(elems.captain_name, checkEmpty);
	result &= validateName(elems.second, checkEmpty);
	result &= validateName(elems.third, checkEmpty);

	result &= validateEmail(elems.captain_email, checkEmpty);

	result &= validatePhone(elems.captain_number, checkEmpty);

	result &= validateCity(elems.cityDropDown, elems.city_text, checkEmpty);

    if (!result) {
        alert("Форма заполнена некорректно");
    }

    return result ? true : false;
}

function validateIsEmpty(container, checkEmpty) {
	resetError(container);
	if (checkEmpty && !container.value) {
	    showError(container);
	    return false;
	}
    return true;
}

function validateCity(container1, container2, checkEmpty) {
    resetError(container2);
    if (checkEmpty && container1.value === "-" && (container2.value === "-" || !container2.value)) {
        showError(container2);
        return false;
    }
    return true;
}

function validateName(container, checkEmpty) {
	resetError(container);
	var expr = /^[a-zA-Zа-яА-Я'][a-zA-Zа-яА-Я-' ]+[a-zA-Zа-яА-Я']?$/;
	if ((checkEmpty && !container.value) || container.value.replace(expr, '').length > 0) {
	    showError(container);
	    return false;
	}
    return true;
}

function validateEmail(container, checkEmpty) {
	resetError(container);
	var expr = /^[-a-z0-9~!$%^&*_=+}{\'?]+(\.[-a-z0-9~!$%^&*_=+}{\'?]+)*@([a-z0-9_][-a-z0-9_]*(\.[-a-z0-9_]+)*\.(aero|arpa|biz|com|coop|edu|gov|info|int|mil|museum|name|net|org|pro|travel|mobi|[a-z][a-z])|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,5})?$/i;
	if ((checkEmpty && !container.value) || container.value.replace(expr, '').length > 0) {
	    showError(container);
	    return false;
	}
    return true;
}

function validatePhone(container, checkEmpty) {
	resetError(container);
	var expr = /^(?:(?:\(?(?:00|\+)([1-4]\d\d|[1-9]\d?)\)?)?[\-\.\ \\\/]?)?((?:\(?\d{1,}\)?[\-\.\ \\\/]?){0,})(?:[\-\.\ \\\/]?(?:#|ext\.?|extension|x)[\-\.\ \\\/]?(\d+))?$/i;
	if ((checkEmpty && !container.value) || container.value.replace(expr, '').length > 0) {
		showError(container);
		return false;
    }
    return true;
}

function configureForm(form, checkEmpty){
  var elements = form.getElementsByTagName("input");
  console.log('set events to inputs ');
  console.log(elements.length);
  for (i=0; i<elements.length; i++){
    elements[i].onblur = function() { validateForm(form, false); }
    elements[i].onfocus = function() { resetError(this); }
  }
}

configureForm(document.forms.registration_form);