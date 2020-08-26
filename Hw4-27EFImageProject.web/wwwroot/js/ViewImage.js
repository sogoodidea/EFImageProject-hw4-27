$(() => {
    $("#like-image").on('click', function () {
        const id = $(this).data('image-id');
        console.log(id);
        $.post('/home/likeImage', { id } , function () {            
            //disable the button while user is here. Sessions will ensure the next time they come to page, it's also disabled
            $("#like-image").prop('disabled', true);
        })
     });

    setInterval(() => {
        const imageId = $("#current-image").data('image-id');
        //console.log('it came here');
        $.get(`/home/getLikes?imageId=${imageId}`, function (likes) {
        console.log(likes);
            $("#likes-amount").text(`${likes} Likes`);
        });
        //go back to the database and check the amount of likes for this image and update on the page they're viewing
    }, 500)
});