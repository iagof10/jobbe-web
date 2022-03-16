/**
 *
 * Lists
 *
 * Interface.Plugins.List.html page content scripts. Initialized from scripts.js file.
 *
 *
 */

class Lists {
    constructor() {
        if (typeof List === 'undefined') {
            console.log('List is undefined!');
            return;
        }

        this._initExistingHtmlList();
        this._initExistingHtmlListScrollbar();
        this._initAddingViaJS();
        this._initSortAndFilter();
        this._initSortFilterAndPagination();
    }

    // List with existing HTML
    _initExistingHtmlList() {
        if (document.getElementById('existingHtmlList')) {
            var existingHtmlList = new List('existingHtmlList', { valueNames: ['name', 'position'] });
        }
    }

    // Scrollable list with existing html
    _initExistingHtmlListScrollbar() {
        if (document.getElementById('existingHtmlListScrollbar')) {
            // Custom listClass to make it work with OverlayScrollbar
            var existingHtmlListScrollbar = new List('existingHtmlListScrollbar', { valueNames: ['name', 'position'], listClass: 'os-content' });
        }
    }

    // Creating list by adding from js
    _initAddingViaJS() {
        if (document.getElementById('addingViaJS')) {

            var options = {
                item: 'addingViaJSlItemTemplate',
                valueNames: ['name', { name: 'image', attr: 'src' }, { name: 'id', attr: 'id' }],
            };

            const ajax = new XMLHttpRequest();
            ajax.open('GET', 'http://51.222.19.201:8081/api/Categoria');
            ajax.responseType = 'json';
            ajax.onload = function (e) {
                if (this.status == 200) {
                    console.log('response', this.response); // JSON response  
                    var values = this.response.data
                    var addingViaJS = new List('addingViaJS', options, values);
                }
            };

            ajax.send();
        }
    }

    // Sorting and filtering a scrollable list
    _initSortAndFilter() {
        if (document.getElementById('sortAndFilter')) {
            var sortAndFilter = new List('sortAndFilter', { valueNames: ['name', 'category', 'sale'], listClass: 'os-content' });

            document.querySelectorAll('#sortAndFilter .filter').forEach((el) => {
                el.addEventListener('change', (event) => {
                    filterCategory();
                });
            });
        }

        function filterCategory() {
            let selectedCategories = [];
            document.querySelectorAll('#sortAndFilter .filter:checked').forEach((el) => {
                selectedCategories.push(el.getAttribute('data-filter'));
            });
            sortAndFilter.filter((item) => {
                return selectedCategories.indexOf(item.values().category.trim()) >= 0;
            });
        }
    }

    // Sorting and filtering a list with a pagination
    _initSortFilterAndPagination() {
        if (document.getElementById('pagination')) {
            var pagination = new List('pagination', {
                valueNames: ['name', 'category', 'sale'],
                page: 3,
                pagination: [
                    {
                        includeDirectionLinks: true,
                        leftDirectionText: '<i class="cs-chevron-left"></i>',
                        rightDirectionText: '<i class="cs-chevron-right"></i>',
                        liClass: 'page-item',
                        aClass: 'page-link shadow',
                        innerWindow: 1000, // Hiding ellipsis
                    },
                ],
            });
            document.querySelectorAll('#pagination .filter').forEach((el) => {
                el.addEventListener('change', (event) => {
                    filterCategory();
                });
            });
        }
        function filterCategory() {
            let selectedCategories = [];
            document.querySelectorAll('#pagination .filter:checked').forEach((el) => {
                selectedCategories.push(el.getAttribute('data-filter'));
            });
            pagination.filter((item) => {
                return selectedCategories.indexOf(item.values().category.trim()) >= 0;
            });
        }
    }
}