var tt = document.querySelector("#letter_effect").textContent
var partsOfStr = tt.split(',');
var _CONTENT = partsOfStr
var _PART = 0;
var _PART_INDEX = 0;
var _INTERVAL_VAL;
var _ELEMENT = document.querySelector("#text");
var _CURSOR = document.querySelector("#cursor");
function Type() {
    var text = _CONTENT[_PART].substring(0, _PART_INDEX + 1);
    _ELEMENT.innerHTML = text;
    _PART_INDEX++;
    if (text === _CONTENT[_PART]) {
        _CURSOR.style.display = 'none';
        clearInterval(_INTERVAL_VAL);
        setTimeout(function () {
            _INTERVAL_VAL = setInterval(Delete, 50);
        }, 1000);
    }
}
function Delete() {
    var text = _CONTENT[_PART].substring(0, _PART_INDEX - 1);
    _ELEMENT.innerHTML = text;
    _PART_INDEX--;
    if (text === '') {
        clearInterval(_INTERVAL_VAL);
        if (_PART == (_CONTENT.length - 1))
            _PART = 0;
        else
            _PART++;

        _PART_INDEX = 0;
        setTimeout(function () {
            _CURSOR.style.display = 'inline-block';
            _INTERVAL_VAL = setInterval(Type, 100);
        }, 200);
    }
}
_INTERVAL_VAL = setInterval(Type, 100);



var modal = document.getElementById("myModal");
var btn = document.getElementById("myBtn");
function openForm() {
    modal.style.display = "block";
    document.body.style.overflow = "hidden";

}
function closeForm() {
    modal.style.display = "none";
    document.body.style.overflow = "visible";

}
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
        document.body.style.overflow = "visible";

    }
}




function Dotss() {
    var dotsOneToFive = [
        `  <span class="dot-fill"></span><span class="dot"></span><span class="dot" ></span><span class="dot"></span><span class="dot"></span>`,
        `  <span class="dot-fill"></span><span class="dot-fill"></span><span class="dot" ></span><span class="dot"></span><span class="dot"></span>`,
        `  <span class="dot-fill"></span><span class="dot-fill"></span><span class="dot-fill" ></span><span class="dot"></span><span class="dot"></span>`,
        `  <span class="dot-fill"></span><span class="dot-fill"></span><span class="dot-fill" ></span><span class="dot-fill"></span><span class="dot"></span>`,
        `  <span class="dot-fill"></span><span class="dot-fill"></span><span class="dot-fill" ></span><span class="dot-fill"></span><span class="dot-fill"></span>`
    ]

    for (let i = 1; i < 6; i++) {
        var dd = document.getElementsByClassName(`dots-${i}`)
        if (dd.length = 0) { continue }
        else {
            for (let j = 0; j < dd.length; j++) {
                dd[j].innerHTML += dotsOneToFive[i - 1]
            
            }
        }
    }
}

function PHeader() {
    var ph = document.getElementById("page-meta").innerText
    document.title = ph
}


window.onload = function () {
    Dotss(); PHeader();
};
