var isSelectX = true;
$(document).ready(function () {
    $('#btn-accept').click(function () {
        var countBox = $('#size-board').val();

        var html = '';

        for (var i = 0; i < countBox; i++) {
            html += '<tr>';
            for (var j = 0; j < countBox; j++) {
                html += '<td><button id="box-'+i+'-'+j+'" class="btn btn-default box"></button></td>';
            }
            html += '</tr>';
        }

        $('#board-game tbody').empty().append(html);
    });

    /*
     nếu ô chưa có gì thì xét isSelectX:
     - vì isSelectX = false nên O sẽ xuất hiện đầu tiên
     - khi xét đến X thì isSelectX sẽ được đổi thành true, lúc này X sẽ xuất hiện
     */
    $('body').on('click', ".box", function () {
        if ($(this).text() == '') {
            var countBox = $('#size-board').val();
            isSelectX = !isSelectX; // = false

            if (isSelectX) {
                var selector = 'X';
                var cssSelector = 'box-x';
            } else {
                selector = 'O';
                cssSelector = 'box-o';
            }

            $(this).text(selector).addClass(cssSelector);

            // check win
            var arr = $(this).attr('id').split('-');
            var currentRow = parseInt(arr[1]);
            var currentCol = parseInt(arr[2]);
            var row = -1;
            var col = -1;
            var countWin = -1;

            var COUNTWIN = 5;

            // check ngang
            countWin = 1;
            // check ngang trái
            row = currentRow;
            col = currentCol - 1;
            while (col >= 0) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    col--;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // check ngang phải
            row = currentRow;
            col = currentCol + 1;
            while (col < countBox) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    col++;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // check dọc theo chiều đi lên
            countWin = 1;
            col = currentCol;
            row = currentRow - 1;
            while (row >= 0) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    row--;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // check dọc theo chiều đi xuống
            col = currentCol;
            row = currentRow + 1;
            while (row < countBox) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    row++;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // chéo xuống(lên) góc trái(phải)
            // check theo đường chéo đi lên
            col = currentCol + 1;
            row = currentRow - 1;
            while (row >= 0 && col < countBox) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    col++;
                    row--;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // check theo đường chéo đi xuống
            col = currentCol - 1;
            row = currentRow + 1;
            while (col >= 0 && row < countBox) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    col--;
                    row++;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // chéo xuống(lên) góc phải(trái)
            // chéo đi lên
            col = currentCol - 1;
            row = currentRow - 1;
            while (col >= 0 && row >= 0) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    col--;
                    row--;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }

            // chéo đi xuống
            col = currentCol + 1;
            row = currentRow + 1;
            while (col < countBox && row < countBox) {
                var element = '#box-' + row + '-' + col;
                if ($(element).text() == selector) {
                    countWin++;
                    col++;
                    row++;
                } else {
                    break;
                }
            }
            if (countWin >= COUNTWIN) {
                console.log("win");
            }
        }
    });
});