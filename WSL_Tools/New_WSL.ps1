param(
    $Name,
    $Image = "$HOME\Projects\WSL_Ubuntu_Preconfigured.vhdx",
    $Location = "$HOME\WSL\$Name\"
)

wsl --import --vhd $Name $Location $Image