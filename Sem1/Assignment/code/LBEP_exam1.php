<?php
	$choice = 1;
	while($choice != 3){
		echo "************************\n";
		echo "PHP Program Language\n";
		echo "\t1. Question 02.\n";
		echo "\t2. Question 03.\n";
		echo "\t3. Exit\n";
		echo "************************\n";
		$choice =readline("\t Enter Choice (1 - 3): ");
		if($choice == 1){
		$x = readline("Enter an integer: ");
		$fac = 1;
		for($i = 1; $i <= $x; $i++){
			$fac = $fac* $i;
		};
		echo "Factorial: {$x}! = {$fac}\n\n";
		} elseif ($choice ==2){
			$num_book = readline("How many books would you like to manage: ");
			while($num_book > 5){
				echo "The number is invalid! Try again\n";
				$num_book = readline("\nHow many books would you like to manage: ");
			};
			$books = array();
			$quantity = array();
			$price = array();
			for($i = 0; $i < $num_book; $i++){
				$j = $i+1;
				$book_name = readline("Enter book {$j} name: ");
				array_push($books, $book_name);
				$quan = readline("Enter quantity: ");
				$pric = readline("Enter Unit price: ");
				array_push($quantity,$quan);
				array_push($price,$pric);
				echo "\n";
			};
			echo "Book List Information:\n";
			echo "No\t\tName\tQuantity Price Amount\n";
			echo "___|__________________|_______|______|_______\n";
			for($i = 0; $i < count($books); $i++){
				$j = $i+1;
				$amount = $quantity[$i]*$price[$i];
				echo "{$j}   {$books[$i]}\t{$quantity[$i]}\t{$price[$i]} {$amount}\n";
			}
		}
	};
	if($choice == 3){
		echo "Goodbye!\n";
	}
