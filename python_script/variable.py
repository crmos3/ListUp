import re
import codecs

text_data = ""
with codecs.open("variable.txt", 'r', "utf-8") as f:
    text_data = f.read()

result = re.finditer(r"class [^ ]+ ", text_data)
for match in result:
    result = match.group()
    break

result = re.finditer(r"[^ ]+", result)
next(result)
class_name = next(result).group()
print("class name is " + class_name)

result = re.finditer(r"(private|public|internal)+ [^ ]+ [^\r\n]+;", text_data)

variables = []
i = 0
for matches in result:
    #print(matches.group())
    variable_text = re.finditer(r"[^ ;]+", matches.group())
    for match in variable_text:
        print(match.group())
        if i % 3 == 0:
            pass
        if i % 3 == 1:
            variable_type = match.group()
            if variable_type == "const" or variable_type == "static":
                break
        if i % 3 == 2:
            variable_name = match.group()
            variables.append([variable_type, variable_name])
            i = 0
            break
        i += 1

output = ""
for variable in variables:
    if variable[0] == "int" or variable[0] == "float":
        output += "\
            \tname = \"{1}\";\n\
            \toutput.Append(AccessTools.FieldRefAccess<{2}, {0}>(value, \"{1}\").ToString() + Separator);\n\
            \tif(header != null && !header.Contains(\"{1}\")) header.Add(\"{1}\");\n\n".format(variable[0], variable[1], class_name)
    else:
        output += "\
            \tname = \"{1}\";\n\
            \t{{var field = AccessTools.FieldRefAccess<{2}, {0}>(value, \"{1}\");\
            \tint canCast = (int)field;\n\
            \toutput.Append(({0})canCast + Separator);\n\
            \tif(header != null && !header.Contains(\"{1}\")) header.Add(\"{1}\");\n\
            \t}}\n\n".format(variable[0], variable[1], class_name)

print(output)