sampler2D implicitInputSampler : register(S0);
float4 topLeftColor : register(c0);
float4 topRightColor : register(c1);
float4 bottomLeftColor : register(c2);
float4 bottomRightColor : register(c3);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 topColor = lerp(topLeftColor, topRightColor, uv.x);
    float4 bottomColor = lerp(bottomLeftColor, bottomRightColor, uv.x);
	
    return lerp(topColor, bottomColor, uv.y);
}