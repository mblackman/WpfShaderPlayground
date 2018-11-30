sampler2D image : register(S0);
float redChannel : register(C0);
float greenChannel : register(C1);
float blueChannel : register(C2);

float4 main(float2 uv : TEXCOORD) : COLOR {
    float4 color = tex2D(image, uv.xy);
    return color - float4(redChannel, greenChannel, blueChannel, 0);
}