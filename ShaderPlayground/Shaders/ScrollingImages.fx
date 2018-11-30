sampler2D input : register(S0);
sampler2D scrollingImage : register(S1);

float horizontalScrollSpeed : register(c0);
float verticalScrollSpeed: register(c1);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 backgroundColor = tex2D(input, uv.xy).rgba;
    float4 foregroundColor = tex2D(scrollingImage, uv.xy).rgba;

    return lerp(backgroundColor, foregroundColor, 1);
}