param(
    $Distro = 'Ubuntu',
    $Name = 'WSL_Ubuntu_Preconfigured'
)

wsl --export --vhd $Distro $HOME/Projects/$Name.vhdx