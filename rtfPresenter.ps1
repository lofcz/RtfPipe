$rawContent = Get-Content ./test.rtf -Raw
$nesting = 0
$newLines =foreach($item in $($($rawContent -replace '[{}]','`r`n$0`r`n') -split '`r`n'))
{
    if($item -eq '}')
    {
        $nesting = $nesting -1
    }

    " " * (4*$nesting) + $item

    if($item -eq '{')
    {
        $nesting = $nesting+1
    }
}
$newLines -join "`r`n" | Out-File "formatted.txt"