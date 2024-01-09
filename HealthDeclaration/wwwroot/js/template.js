let fieldCounter = 1;

$("#TemplateForm").validate({
    // Define validation rules and settings here
    rules: {
        // Specify rules for form fields
        template_name: "required",
        // More rules for other fields if needed
    },
    messages: {
        // Custom error messages for fields can be defined here
        name: "Please enter your name",
        // More messages for other fields if needed
    }
});

$("#btnAdd").on("click", function (event) {
    event.preventDefault(); // Prevent default button behavior
    console.log("AddClick");
    // Check form validity when the button is clicked
    if ($("#TemplateForm").valid()) {
        // If the form is valid, perform your action here
        // For example, submit the form
        //$("#TemplateForm").submit();
    }
});

$("#btnNew").on("click", function (_e) {
    _e.preventDefault();
    let a = document.createElement('a');
    a.href = "/Templates/Template";
    document.body.append(a);
    a.click();
    a.remove();
});



console.log("Template JS");
function addField() {
    const templateFieldsDiv = document.getElementById('templateFields');

    const fieldContainer = document.createElement('div');
    fieldContainer.classList.add('template-field');

    const label = document.createElement('label');
    label.textContent = `Field ${fieldCounter}:`;

    const inputTypeSelect = document.createElement('select');
    inputTypeSelect.innerHTML = '<option value="text">Input Text</option><option value="dropdown">Dropdown</option><option value="checkbox">Checkbox</option><option value="radio">Radio Box</option>';

    const deleteBtn = document.createElement('button');
    deleteBtn.textContent = 'Delete';
    deleteBtn.addEventListener('click', function () {
        templateFieldsDiv.removeChild(fieldContainer);
    });

    fieldContainer.appendChild(label);
    fieldContainer.appendChild(inputTypeSelect);
    fieldContainer.appendChild(deleteBtn);
    templateFieldsDiv.appendChild(fieldContainer);

    fieldCounter++;
}

const addFieldBtn = document.getElementById('addFieldBtn');
addFieldBtn.addEventListener('click', addField);