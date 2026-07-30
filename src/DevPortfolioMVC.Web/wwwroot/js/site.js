// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

document.querySelectorAll("[data-project-image]").forEach((image) => {
    const hideUnavailableImage = () => {
        const container = image.closest("[data-project-image-container]");

        if (container) {
            container.hidden = true;
        }
    };

    if (image.complete && image.naturalWidth === 0) {
        hideUnavailableImage();
        return;
    }

    image.addEventListener("error", hideUnavailableImage, { once: true });
});
