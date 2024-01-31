document.addEventListener("DOMContentLoaded", function () {
    var currentImageIndex = 0;
    var imageChangeInterval;
    var imagePaths = [
        'images/logoPlace.png',
        'images/logoPlace4.png'
    ];

    var imgElement = document.getElementById('logoPlace');

    // Function to change the image
    function changeImage() {
        currentImageIndex = (currentImageIndex + 1) % imagePaths.length;
        imgElement.src = imagePaths[currentImageIndex];
    }

    // Start changing images on mouseover
    imgElement.addEventListener('mouseover', function () {
        clearInterval(imageChangeInterval); // Clear existing interval if any
        imageChangeInterval = setInterval(changeImage, 500);
    });

    // Stop changing images on mouseout
    imgElement.addEventListener('mouseout', function () {
        clearInterval(imageChangeInterval);
    });
});


// Script pour l'école
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('selRole').addEventListener('change', function () {
        var value = this.value;
        var secondDropDown = document.getElementById('selSchool');
        if (value == 'Étudiant' || value == 'Enseignant') {
            secondDropDown.style.display = 'block';
        } else {
            secondDropDown.style.display = 'none';
        }
    });
});


// Script pour le groupe
document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('selSchool').addEventListener('change', function () {
        var groupDropDown = document.getElementById('selGroup');
        if (this.value) {  // Si une école est sélectionnée
            groupDropDown.style.display = 'block';
        } else {
            groupDropDown.style.display = 'none';
        }
    });
});


// Script pour la validation des champs

document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('form-inscription').addEventListener('submit', function (e) {
        e.preventDefault();

        var fName = document.getElementById('fName');
        var lName = document.getElementById('lName');
        var oName = document.getElementById('oName');
        var email = document.getElementById('newEmail');
        var password = document.getElementById('newPassword');
        var role = document.getElementById('selRole');
        var school = document.getElementById('selSchool');
        var group = document.getElementById('selGroup');

        var isValid = true;

        // Réinitialiser les placeholders et les styles par défaut
        [fName, lName, oName, email, password].forEach(function (element) {
            element.style.borderColor = 'red';
            element.placeholder = element.getAttribute('data-default-placeholder');
        });

        // Validation des champs obligatoires
        if (!oName.value.trim() && (!fName.value.trim() || !lName.value.trim())) {
            [fName, lName, oName].forEach(function (element) {
                element.style.borderColor = 'red';
                element.placeholder = "Votre nom et prénom ou le nom de l'organisation est requis";

            });
            isValid = false;
        }

        if (!email.value.trim()) {
            email.style.borderColor = 'red';
            email.placeholder = 'Votre adresse courriel est requise';
            isValid = false;
        }

        if (!password.value.trim()) {
            password.style.borderColor = 'red';
            password.placeholder = 'Vous devez choisir un mot de passe';
            isValid = false;
        }



        // Validation of role
        if (role.value === '' || role.value === 'Faire votre sélection') {
            alert('Veuillez sélectionner votre rôle.');
            isValid = false;
        }


        // Validation of school for specific roles
        if ((role.value === 'Étudiant' || role.value === 'Enseignant') && (school.value === '' || school.value === 'Votre école')) {
            alert('En tant qu\'Étudiant ou Enseignant, veuillez sélectionner votre école.');
            isValid = false;
        }
        // Validation of group if a school is selected
        if ((role.value === 'Étudiant' || role.value === 'Enseignant') && school.value !== 'Votre école' && (group.value === '' || group.value === 'Votre groupe')) {
            alert('Veuillez sélectionner votre groupe.');
            isValid = false;
        }

        return isValid;


    });
});

