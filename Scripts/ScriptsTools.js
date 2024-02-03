function mostrarCaminhoArquivo(input) {
    var fileName = input.files[0].name;
    document.getElementById('origemArquivo').value = fileName;
}