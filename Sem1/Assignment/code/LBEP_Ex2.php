<?php
    $x = readline("Enter the width of Rectangle: ");
    $y = readline("Enter the high of Rectangle: ");
    $per = ($x + $y)*2;
    $area = $x * $y;
    echo "\tPerimeter of the Rectangle: 2 * ( {$x} + {$y}) = {$per}\n";
    echo "\tArea of the Rectangle: {$x} * {$y} = {$area}\n";