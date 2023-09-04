window.addEventListener("scroll", function () {
    var pageTop = window.pageYOffset || document.documentElement.scrollTop;
    var pageBottom = pageTop + window.innerHeight;
    var tags = document.querySelectorAll(".fade-in-on-scroll");

    tags.forEach(function (tag) {
        var tagTop = tag.getBoundingClientRect().top + pageTop;
        if (tagTop < pageBottom) {
            tag.classList.add("visible");
        } else {
            tag.classList.remove("visible");
        }
    });
});