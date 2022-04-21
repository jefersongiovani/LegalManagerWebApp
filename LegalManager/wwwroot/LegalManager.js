(function () {
    'use strict';

    // Update 'version' to refresh the cache
    var version = 'legal-manager-bsc-v1.2.3';
    var offlineUrl = "Home/offline.cshtml"; // <-- Offline/Index.cshtml

    var urlsToCache = ['/',
        './images/icons/apple-touch-icon.png',
        './images/icons/icon-512x512.png',
        './images/icons/icon-192x192.png',
        './images/icons/icon-384x384.png',
        './images/icons/icon-152x152.png',
        './images/icons/icon-144x144.png',
        './images/icons/icon-128x128.png',
        './images/icons/icon-72x72.png',
        './images/icons/icon-96x96.png',
        './images/brand.png',
        './images/brand_dark.png',
        './images/favicon.ico',
        './images/LegalManager_logo.png',
        './assets/css/animate.min.css',
        './assets/css/bootstrap.min.css',
        './assets/css/light-bootstrap-dashboard.css',
        './assets/css/pe-icon-7-stroke.css',
        './assets/fonts/Pe-icon-7-stroke.eot',
        './assets/fonts/Pe-icon-7-stroke.svg',
        './assets/fonts/Pe-icon-7-stroke.ttf',
        './assets/fonts/Pe-icon-7-stroke.woff',
        './assets/js/light-bootstrap-dashboard.js',
        './assets/js/bootstrap.min.js',
        './assets/js/bootstrap-notify.js',
        './assets/js/bootstrap-select.js',
        './assets/js/chartist.min.js',
        './themes/calendar_g.css',
        './themes/calendar_green.css',
        './themes/calendar_traditional.css',
        './themes/calendar_transparent.css',
        './themes/calendar_white.css',
        './lib/daypilot/daypilot-all.min.d.ts',
        './lib/daypilot/daypilot-all-min.js',
        './lib/daypilot/daypilot-modal.min.js'




        ]; // <-- Add more URLs you would like to cache.

    // Store core files in a cache (including a page to display when offline)

    function updateStaticCache() {
        return caches.open(version)
            .then(function (cache) {
                return cache.addAll(urlsToCache);
            });
    }

    function addToCache(request, response) {
        if (!response.ok && response.type !== 'opaque')
            return;

        var copy = response.clone();
        caches.open(version)
            .then(function (cache) {
                cache.put(request, copy);
            });
    }

    function serveOfflineImage(request) {
        if (request.headers.get('Accept').indexOf('image') !== -1) {
            return new Response('<svg role="img" aria-labelledby="offline-title" viewBox="0 0 400 300" xmlns="http://www.w3.org/2000/svg"><title id="offline-title">Offline</title><g fill="none" fill-rule="evenodd"><path fill="#D8D8D8" d="M0 0h400v300H0z"/><text fill="#9B9B9B" font-family="Helvetica Neue,Arial,Helvetica,sans-serif" font-size="72" font-weight="bold"><tspan x="93" y="172">offline</tspan></text></g></svg>', { headers: { 'Content-Type': 'image/svg+xml' } });
        }
    }

    self.addEventListener('install', function (event) {
        event.waitUntil(updateStaticCache());
    });

    self.addEventListener('activate', function (event) {
        event.waitUntil(
            caches.keys()
                .then(function (keys) {
                    // Remove caches whose name is no longer valid
                    return Promise.all(keys
                        .filter(function (key) {
                            return key.indexOf(version) !== 0;
                        })
                        .map(function (key) {
                            return caches.delete(key);
                        })
                    );
                })
        );
    });

    self.addEventListener('fetch', function (event) {
        var request = event.request;

        // Always fetch non-GET requests from the network
        if (request.method !== 'GET' || request.url.match(/\/browserLink/ig)) {
            event.respondWith(
                fetch(request)
                    .catch(function () {
                        return caches.match(offlineUrl);
                    })
            );
            return;
        }

        // For HTML requests, try the network first, fall back to the cache, finally the offline page
        if (request.headers.get('Accept').indexOf('text/html') !== -1) {
            event.respondWith(
                fetch(request)
                    .then(function (response) {
                        // Stash a copy of this page in the cache
                        addToCache(request, response);
                        return response;
                    })
                    .catch(function () {
                        return caches.match(request)
                            .then(function (response) {
                                return response || caches.match(offlineUrl);
                            });
                    })
            );
            return;
        }

        // cache first for fingerprinted resources
        if (request.url.match(/(\?|&)v=/ig)) {
            event.respondWith(
                caches.match(request)
                    .then(function (response) {
                        return response || fetch(request)
                            .then(function (response) {
                                addToCache(request, response);
                                return response || serveOfflineImage(request);
                            })
                            .catch(function () {
                                return serveOfflineImage(request);
                            });
                    })
            );

            return;
        }

        // network first for non-fingerprinted resources

        event.respondWith(
            fetch(request)
                .then(function (response) {
                    // Stash a copy of this page in the cache
                    addToCache(request, response);
                    return response;
                })
                .catch(function () {
                    return caches.match(request)
                        .then(function (response) {
                            return response || serveOfflineImage(request);
                        })
                        .catch(function () {
                            return serveOfflineImage(request);
                        });
                })
        );
    });

})();