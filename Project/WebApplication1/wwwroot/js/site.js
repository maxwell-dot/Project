// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
<script>
    window.onload = function() {
            // Show the banner
            var banner = document.getElementById("banner");
    banner.style.display = "block";

    // Set a timer to hide the banner after 5 seconds (5000 milliseconds)
    setTimeout(function() {
        banner.style.display = "none";
            }, 5000); // 5000 ms = 5 seconds
        };
</script>