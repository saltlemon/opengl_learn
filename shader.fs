#version 330 core

struct Material{
	float shininess;
	float ambWeight;
	float diffWeight;
	float specWeight;
	sampler2D diffTex;
	sampler2D specTex;
};

out vec4 fragColor;

in vec3 normal;
in vec3 worldPos;
in vec2 texCoords;

uniform Material material;
uniform vec3 lightColor;
uniform vec3 lightPos;
uniform vec3 camPos;
void main()
{
    vec3 amb = texture(material.diffTex, texCoords).rgb*material.ambWeight;
    

	vec3 n=normalize(normal);
	vec3 lightDir = normalize(worldPos-lightPos);
	vec3 diff = max(dot(n, -lightDir), 0.0)* texture(material.diffTex, texCoords).rgb
	* material.diffWeight ;
	
	vec3 view=normalize(worldPos-camPos);
	vec3 halfV=-normalize(view+lightDir);
	vec3 spec = pow(max(dot(n,halfV), 0.0), material.shininess) 
	* texture(material.specTex, texCoords).rgb*material.specWeight;
	
	vec3 result = (amb+diff+spec)*lightColor;
    fragColor = vec4(result, 1.0);
	
}