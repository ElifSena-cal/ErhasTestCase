(function ($) {
    "use strict"

    // NAVIGATION
    var responsiveNav = $('#responsive-nav'),
        catToggle = $('#responsive-nav .category-nav .category-header'),
        catList = $('#responsive-nav .category-nav .category-list'),
        menuToggle = $('#responsive-nav .menu-nav .menu-header'),
        menuList = $('#responsive-nav .menu-nav .menu-list');

    catToggle.on('click', function () {
        menuList.removeClass('open');
        catList.toggleClass('open');
    });

    menuToggle.on('click', function () {
        catList.removeClass('open');
        menuList.toggleClass('open');
    });

    $(document).click(function (event) {
        if (!$(event.target).closest(responsiveNav).length) {
            if (responsiveNav.hasClass('open')) {
                responsiveNav.removeClass('open');
                $('#navigation').removeClass('shadow');
            } else {
                if ($(event.target).closest('.nav-toggle > button').length) {
                    if (!menuList.hasClass('open') && !catList.hasClass('open')) {
                        menuList.addClass('open');
                    }
                    $('#navigation').addClass('shadow');
                    responsiveNav.addClass('open');
                }
            }
        }
    });

    // HOME SLICK
    $('#home-slick').slick({
        autoplay: true,
        infinite: true,
        speed: 300,
        arrows: true,
    });

    // PRODUCTS SLICK
    $('#product-slick-1').slick({
        slidesToShow: 3,
        slidesToScroll: 2,
        autoplay: true,
        infinite: true,
        speed: 300,
        dots: true,
        arrows: false,
        appendDots: '.product-slick-dots-1',
        responsive: [{
            breakpoint: 991,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
            }
        },
        {
            breakpoint: 480,
            settings: {
                dots: false,
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1,
            }
        },
        ]
    });

    $('#product-slick-2').slick({
        slidesToShow: 3,
        slidesToScroll: 2,
        autoplay: true,
        infinite: true,
        speed: 300,
        dots: true,
        arrows: false,
        appendDots: '.product-slick-dots-2',
        responsive: [{
            breakpoint: 991,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
            }
        },
        {
            breakpoint: 480,
            settings: {
                dots: false,
                arrows: true,
                slidesToShow: 1,
                slidesToScroll: 1,
            }
        },
        ]
    });

    // PRODUCT DETAILS SLICK
    $('#product-main-view').slick({
        infinite: true,
        speed: 300,
        dots: false,
        arrows: true,
        fade: true,
        asNavFor: '#product-view',
    });

    $('#product-view').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        arrows: true,
        centerMode: true,
        focusOnSelect: true,
        asNavFor: '#product-main-view',
    });

    // PRODUCT ZOOM
    $('#product-main-view .product-view').zoom();

    // PRICE SLIDER
    var slider = document.getElementById('price-slider');
    if (slider) {
        noUiSlider.create(slider, {
            start: [1, 999],
            connect: true,
            tooltips: [true, true],
            format: {
                to: function (value) {
                    return value.toFixed(2) + '$';
                },
                from: function (value) {
                    return value
                }
            },
            range: {
                'min': 1,
                'max': 999
            }
        });
    } 


})(jQuery);
;
function loadProducts(categoryId) {
    $.ajax({
        url: '/Product/LoadProducts',
        type: 'GET',
        data: { categoryId: categoryId },
        success: function (data) {
            $('#productList').empty();
            $('#productList').html(data);
        },
        error: function (xhr, status, error) {
            console.error('AJAX request failed:', error);
        }
    });
}
function adjustQuantity(event, BasketItemId, change) {
    event.stopPropagation();
    const quantityElement = document.getElementById(BasketItemId);
    let currentQuantity = parseInt(quantityElement.value, 10);
    currentQuantity += change;

    if (currentQuantity < 0) {
        currentQuantity = 0;
    }

    quantityElement.value = currentQuantity;
    updateBasket(BasketItemId);
    updateCartBadge();
}

function addToBasket(productId) {
    $.ajax({
        type: "POST",
        url: '/Basket/AddToBasket',
        data: { ProductId: productId },
        success: function (response) {
            $('#dropdownMenu').empty();
            $('#dropdownMenu').html(response);
            updateCartBadge();
            toastr.success('Ürün Eklendi');
        },
        error: function (xhr) {
            if (xhr.status === 401) {
                toastr.error('Sepete ürün eklemek için kayıt olmanız gerekmektedir');
            } else {
                toastr.error('Ürün Ekleme hatası');
            }
        }
    });
}


function removeFromBasket(BasketItemId) {
    if (confirm('Bu ürünü sepetten kaldırmak istediğinizden emin misiniz?')) {
        $.ajax({
            url: '/Basket/RemoveBasketItem', 
            type: 'POST',
            data: { basketItemId: BasketItemId },
            success: function (response) {
                $('#' + BasketItemId).remove();
                toastr.success('Ürün sepetten kaldırıldı');
                updateSummary();
            },
             error: function(xhr, status, error) {
                console.error('Ürün kaldırılırken bir hata oluştu:', xhr.responseText);
                alert('Ürün kaldırılırken bir hata oluştu: ' + xhr.responseText);
            }
        });
    }
}

function updateSummary() {
    let subtotal = 0;
    $('.total-price').each(function () {
        subtotal += parseFloat($(this).text().replace('$', ''));
    });

    let shippingCost = 10;
    let taxRate = 0.18;
    let taxAmount = subtotal * taxRate;
    let totalAmount = subtotal + shippingCost + taxAmount;

    $('#subtotal').text('$' + subtotal.toFixed(2));
    $('#taxAmount').text('$' + taxAmount.toFixed(2));
    $('#totalAmount').text('$' + totalAmount.toFixed(2));
}

function updateBasket(basketItemId) {
    const quantityElement = document.getElementById(basketItemId);
    const quantity = quantityElement.value;
    $.ajax({
        type: "POST",
        url: '/Basket/UpdateQuantity',
        data: { BasketItemId: basketItemId, quantity: quantity },
        success: function (response) {
            $('#dropdownMenu').empty();
            $('#dropdownMenu').html(response);
            toastr.success('Sepet Güncellendi');
        },
        error: function () {
            toastr.error('HATA');
        }
    });
}
function updateCartBadge() {
    let totalQuantity = 0;    $('.dropdown-item').each(function () {
        let quantity = parseInt($(this).find('input').val()) || 0;
        totalQuantity += quantity;
    });

    $('#cart-badge').text(totalQuantity);
}
