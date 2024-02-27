$(function() {
            var selectedClass = "";
            $("p").click(function(){
            selectedClass = $(this).attr("data-rel");
            $("#portfolio").fadeTo(50, 0.1);
                $("#portfolio div").not("."+selectedClass).fadeOut();
            setTimeout(function() {
              $("."+selectedClass).fadeIn();
              $("#portfolio").fadeTo(50, 1);
            }, 500);
                
            });
        });


const smallImages = document.querySelectorAll('.pt');
    const bigImage = document.getElementById('bigImage');
    smallImages.forEach(smallImage => {
        smallImage.addEventListener('click', () => {
            const bigImageUrl = smallImage.getAttribute('data-imgbigurl');
            bigImage.src = bigImageUrl;
        });
    });


var resim = document.getElementsByClassName("pt");
    var kucukResim = document.getElementsByTagName("li");
    var index = 0;
    function galeri(indis){
        index = indis;
        if(index >= resim.length){
            index = 0;
        }
        else if(index < 0){
            index = resim.length - 1;
        }
        for(i = 0; i<resim.length; i++){
            resim[i].classList.remove("aktif");
            kucukResim[i].classList.remove("aktifOnizleme")
        }
        resim[index].classList.add("aktif");
        kucukResim[index].classList.add("aktifOnizleme");
        console.log(index);