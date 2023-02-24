$(fuction() {

    var PlaceHolderElement = $('#PlaceHolderHere'),

    $('button[data-toggle="ajax-model"]').click(fuction(event){
        
        var url = $(this).data('url');
        $.get(url).done(fuction(data) {
            PlaceHolderElement.html(data);
            PlaceHolderElement.find('.model').model('show')
        })

})
