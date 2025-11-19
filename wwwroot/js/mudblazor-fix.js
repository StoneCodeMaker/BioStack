// mudblazor-fix.js - Fixes for MudBlazor components
document.addEventListener('DOMContentLoaded', function() {
    console.log("MudBlazor fixes loaded");

    // Fix for MudBlazor dropdown issues
    fixMudDropdowns();

    // Fix for button click handlers
    fixMudButtons();
});

// Also run fixes when Blazor is fully loaded
document.addEventListener('blazor:interactive', function() {
    console.log("Running MudBlazor fixes after Blazor initialization");

    // Add a small delay to ensure components are rendered
    setTimeout(() => {
        fixMudDropdowns();
        fixMudButtons();
    }, 300);
});

// Fix for MudBlazor dropdowns
function fixMudDropdowns() {
    // Ensure dropdown menus close properly when clicked outside
    document.addEventListener('click', function(event) {
        const openDropdowns = document.querySelectorAll('.mud-popover-open');
        if (openDropdowns.length > 0) {
            // Check if click was outside dropdown
            const clickedInsideDropdown = Array.from(openDropdowns).some(dropdown =>
                dropdown.contains(event.target) ||
                event.target.classList.contains('mud-button') ||
                event.target.closest('.mud-button'));

            if (!clickedInsideDropdown) {
                // Force close by dispatching an event
                window.dispatchEvent(new Event('mousedown'));
            }
        }
    });
}

// Fix for button click handlers
function fixMudButtons() {
    // Ensure buttons are clickable
    document.querySelectorAll('.mud-button').forEach(button => {
        if (!button.getAttribute('data-fixed')) {
            button.setAttribute('data-fixed', 'true');

            // Add a click listener that ensures the Blazor event fires
            button.addEventListener('click', function(e) {
                // If button has blazor attributes but event isn't propagating
                if (this.hasAttribute('blazor:onclick') && !e.detail) {
                    // Create and dispatch a new click event
                    const newEvent = new MouseEvent('click', {
                        bubbles: true,
                        cancelable: true,
                        view: window,
                        detail: 1 // This differentiates from our event
                    });
                    this.dispatchEvent(newEvent);
                }
            });
        }
    });
}
