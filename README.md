# Dungeons and Dragons
Board to play dnd with your friends.

The project is aiming to create an application which can display a board with multiple pieces to use while playing D&D.

Please not that the project is still in early development and is still far from being completed. For the time being the work is being done on the back end library, there is no UI yet.

If you would like to get involved, contribution guidelines are here, and here is how to get started.

# Developper info

## Unit test not discovering
If Visual Studio doesn't find unit tests, fushing the temp files should fix the problem. To do so run the following command in a terminal.

    DEL %TEMP%\VisualStudioTestExplorerExtensions

Or in powershell

    del $env:TEMP\VisualStudioTestExplorerExtensions
