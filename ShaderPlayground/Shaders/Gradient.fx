sampler2D implicitInputSampler : register(S0);
float4 topLeftColor : register(c0);
float4 topRightColor : register(c1);
float4 bottomLeftColor : register(c2);
float4 bottomRightColor : register(c3);

float frequency : register(c4);
float amplitude : register(c5);
float phase : register(c6);

float4 main(float2 uv : TEXCOORD) : COLOR
{
    float4 topColor = lerp(topLeftColor, topRightColor, uv.x);
    float4 bottomColor = lerp(bottomLeftColor, bottomRightColor, uv.x);
    float4 color = lerp(topColor, bottomColor, uv.y);
    float sinValBot = amplitude * sin((uv.x * 3.1415 / frequency) + phase);
    float sinValTop = amplitude * sin((uv.x * 3.1415 / frequency) + phase + 3);
	
    return color - (uv.y > sinValBot ? 0 : uv.y > sinValTop ? 0.5 : 1);
}