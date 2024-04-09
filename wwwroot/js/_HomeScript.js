document.addEventListener("DOMContentLoaded", function () {
    var images = ["/images/modern-healthcare-approach-doctors-using-tablets-records.jpg", "/images/second-image.jpg", "/images/third-image.jpg"]; // List of background images
    var backgroundContainer = document.getElementById("background-container");

    images.forEach(function (image) {
        var backgroundImage = document.createElement("div");
        backgroundImage.classList.add("background-image");
        backgroundImage.style.backgroundImage = `url(${image})`;
        backgroundContainer.appendChild(backgroundImage);
    });
});
