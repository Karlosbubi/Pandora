param(
    $Distro = 'Ubuntu',
    $Name = 'WSL_Ubuntu_Preconfigured',
    $Location = "$HOME/Projects/$Name.vhdx"
)

wsl --export --vhd $Distro $Location