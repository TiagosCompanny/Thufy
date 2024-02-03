function configurarInputArquivo(inputId) {
    var inputArquivo = document.getElementById(inputId);
    var selecionarArquivo = document.getElementById('selecionarArquivo');

    if (selecionarArquivo && inputArquivo) {
        selecionarArquivo.click(); // Simular clique no input de arquivo
        selecionarArquivo.addEventListener('change', function () {
            inputArquivo.value = this.files[0].name;
        });
    } else {
        console.error('Elementos não encontrados. Certifique-se de que os IDs estão corretos.');
    }
}