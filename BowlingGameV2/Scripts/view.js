$(document).ready(function () {
    var game = new Game({});
    $('#frameFields').submit(function(e) {
        e.preventDefault();
        return false;
    });
    $("#frameFields").validate({
        rules: {
            rolle1: {
                required: true,
                number: true,
                min: 0,
                max: 10
            },
            rolle2: {
                required: true,
                number: true,
                min: 0,
                max: 10
            }

        },
        submitHandler: function (form) {
            $("div.error").html("");
            var total = parseInt($("#rolle1").val() || 0) + parseInt($("#rolle2").val() || 0);
            if (total > 10) {
                $("div.error").html("Sum of two fileds should be les or equal with 10.");
                return false;
            } else {
                if (game.frames.length === 10) {
                    $("div.error").html("Game can have max 10 frames!");
                    return false;
                }
                var rolls = new Roll({ first: $('#rolle1').val() || 0, second: $('#rolle2').val() || 0 });//this is a frame
                game.frames.push(rolls);
                var data = game.toJsonData();
                $.post(bowling.config.apiPath + '/GameScore/Frames', data, function (result) {
                    game.score = result.score;
                    $('#bowlingGameScore').html(game.score);
                    $('#frameRolls').append('<li class="list-group-item">' + rolls.toHtml() + '<span class="badge">' + game.score + '</span>' + '</li>');
                    if (game.frames.length === 9) {
                        $('#rolle3Panel').show();
                    }
                });
            };
        }

    });
});

