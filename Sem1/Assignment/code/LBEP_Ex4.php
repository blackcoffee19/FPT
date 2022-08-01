<?php
	echo "***************************************\n";
	echo "\tPHP PROGRAM LANGUGE\n";
	echo "\t1.Question 02.\n";
	echo "\t2.Question 03.\n";
	echo "\t3.Exit\n";
	echo "***************************************\n";
	$choose = readline("Enter Choice (1 - 3): ");
	if($choose == 1){
		$x = readline("Enter the width of Rectangle: ");
		$y = readline("Enter the high of Rectangle: ");
		$per = ($x + $y)*2;
		$area = $x * $y;
		echo "\tPerimeter of the Rectangle: 2 * ({$x} + {$y}) = {$per}\n";
		echo "\tArea of of the Rectangle: {$x} * {$y} = {$area}\n";
	} elseif($choose == 2){
		$m = readline("Enter the radius of Circle: ");
		$per_c = $m *2 *3.14;
		$area_c = $m*$m*3.14;
		echo "\tPerimeter of the Circle: 2 * {$m} *3.14 = {$per_c}\n";
		echo "\tArea of the Circle: {$m} * {$m} *3.14 = {$area_c}\n";
	}else{
		echo "\tGoodbye\n";
	}
