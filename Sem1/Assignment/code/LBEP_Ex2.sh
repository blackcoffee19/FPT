#!/bin/bash
echo "Enter the width of Rectangle: ";
read x;
echo "Enter the high of Rectangle: ";
read y;
per=$((($x + $y)*2));
area=$(($x*$y));
echo "Perimeter of the Rectangle: 2 * ($x + $y) = $per";
echo "Area of the Rectangle: $x * $y = $echo $area";