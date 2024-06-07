#!/bin/sh

rm build.output > /dev/null
set -e;
#Build to detect compilation errors
go build .;

#Recombing all the code into one built go file as
# Codingame only supports single-file submissions
package_statement='package main';
import_statement=$(cat *.go | pcregrep -M 'import.*(\n|.)*\n\)');

#+2 to skip the package statement
gamestate_types=$(tail -n +2 gamestate_types.go);

#+8 to skip the package and import statements
main=$(tail -n +8 main.go);


echo $package_statement >> build.ouput;
echo $import_statement >> build.ouput;
echo $gamestate_types >> build.ouput;
echo $main >> build.ouput;

echo $(cat build.output) | pbcopy;
#rm .output;
