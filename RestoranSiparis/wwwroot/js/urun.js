let urunMiktarı = 1;

function urunEkle() {
    let select = document.createElement("select");
    select.setAttribute("name", "select");

    // 5 tane ürün ekle
    for (let i = 0; i < 5; i++) {
        let option = document.createElement("option");
        option.innerText = "ürün" + (i + 1); // ürün1, ürün2...
        select.appendChild(option); // Option'ı select'e ekle
    }

    // Oluşturulan select'i #urunler div'ine ekle
    document.querySelector("#urunler").appendChild(select);
    urunMiktarı += 1;
}

function urunSil() {
    if (urunMiktarı == 1)
        return;

    let div = document.querySelector("#urunler");
    div.removeChild(div.lastChild); // İlk çocuğu değil, son çocuğu sil
    urunMiktarı -= 1;
}
