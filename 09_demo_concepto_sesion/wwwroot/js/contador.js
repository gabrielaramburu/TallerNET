let contador = 0;

document.addEventListener("DOMContentLoaded", () => {
    const spanValor = document.getElementById("valor-contador");
    const btnIncrementar = document.getElementById("btn-incrementar");

    if (btnIncrementar && spanValor) {
        btnIncrementar.addEventListener("click", () => {
            contador++;
            spanValor.textContent = contador;
        });
    }
});
