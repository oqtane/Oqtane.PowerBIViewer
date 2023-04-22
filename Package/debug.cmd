XCOPY "..\Client\bin\Debug\net6.0\Oqtane.PowerBIViewer.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Client\bin\Debug\net6.0\Oqtane.PowerBIViewer.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Server\bin\Debug\net6.0\Oqtane.PowerBIViewer.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Server\bin\Debug\net6.0\Oqtane.PowerBIViewer.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Shared\bin\Debug\net6.0\Oqtane.PowerBIViewer.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Shared\bin\Debug\net6.0\Oqtane.PowerBIViewer.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net6.0\" /Y
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I
