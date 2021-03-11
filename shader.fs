#version 330 core
out vec4 fragColor;

in vec3 normal;
in vec3 worldPos;
uniform vec3 objectColor;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 camPos;
void main()
{
    float amb = 0.1;
    

	vec3 n=normalize(normal);
	vec3 lightDir = normalize(worldPos-lightPos);
	float diff = max(dot(n, -lightDir), 0.0);
	
	vec3 view=normalize(worldPos-camPos);
	vec3 halfV=-normalize(view+lightDir);
	float spec = pow(max(dot(n,halfV), 0.0), 32);
	
	vec3 result = (amb+diff+spec*0.5)*lightColor* objectColor;
    fragColor = vec4(result, 1.0);
	
}