var MCSASQLImg = "/Content/Photos/MSLogos/MCSASQL2016-logo-Wht.png";
var MCSEDMAImg = "/Content/Photos/MSLogos/MCSEDMA-logo-Wht.png";
var LogoImgClass = "logoImg";
$('#MCSASQL').replaceWith('<img src=' + MCSASQLImg + ' class=' + LogoImgClass + ' id="MCSASQL" />');
$('#MCSASQL').css( "background-color", "rgb(0,114,198)");
$('#MCSEDMA').replaceWith('<img src=' + MCSEDMAImg + ' class=' + LogoImgClass + ' id="MCSEDMA" />');
$('#MCSEDMA').css("background-color", "rgb(70,104,197)");
$(document).ready(function () {
    if ($('.mediaCheck').css('width') === "10px") {
        $('.logoImg').css({ "width": "50%", "height": "50%", "display": "block", "padding": "20px", "margin-top": "10px", "margin-bottom": "10px", "margin-left": "auto", "margin-right": "auto" });
    } else {
        $('.logoImg').css({ "width": "15%", "height": "15%", "display": "inline-block", "padding": "20px", "margin": "20px" });
    }
});
