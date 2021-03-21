#version 330 core
out vec4 FragColor;
in vec2 texCoords;
uniform sampler2D Tex;
void main()
{
    vec4 texColor = texture(Tex, texCoords);
    FragColor = texColor;
}