void __cdecl K3D_RatioSet_C(long ratio)
{
    *(long*)((char*)K3D_gpo_Display + 0x934) = ratio;
}
