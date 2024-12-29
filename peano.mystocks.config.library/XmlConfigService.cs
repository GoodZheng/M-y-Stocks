using System;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace peano.mystocks.config.library
{
    public class XmlConfigService : IConfigService
    {
        private readonly string _filePath;
        private readonly string _rootElementName;
        public XmlConfigService()
        {
            _filePath = ConfigConstants.ConfigFilePath;
            _rootElementName = ConfigConstants.RootElementName;
        }

        // 保存指定的配置类
        public void Save<T>(T data, string? elementName = null)
        {
            try
            {
                // 如果 elementName 为 null，则使用 T 的类名作为默认值
                elementName = elementName ?? typeof(T).Name;

                // 读取现有的配置文件
                XDocument doc = File.Exists(_filePath) ? XDocument.Load(_filePath) : new XDocument(new XElement(_rootElementName));

                // 序列化配置类为 XML 元素
                var serializer = new XmlSerializer(typeof(T));
                using (var reader = new StringWriter())
                {
                    serializer.Serialize(reader, data);
                    var xmlString = reader.ToString();
                    XElement configElement = XElement.Parse(xmlString);

                    // 获取指定的根元素，如果没有则创建
                    XElement rootElement = doc.Element(_rootElementName).Element(elementName);
                    if (rootElement == null)
                    {
                        rootElement = new XElement(elementName);
                        doc.Element(_rootElementName).Add(rootElement);
                    }

                    // 替换现有的配置数据或添加新的数据
                    rootElement.ReplaceWith(configElement);

                    // 保存文件
                    doc.Save(_filePath);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        // 加载指定配置类
        public T Load<T>(string? elementName = null)
        {

            try
            {
                // 如果 elementName 为 null，则使用 T 的类名作为默认值
                elementName = elementName ?? typeof(T).Name;

                if (!File.Exists(_filePath))
                {
                    // 如果文件不存在，则创建默认配置并返回
                    var defaultConfig = Activator.CreateInstance<T>();
                    Save(defaultConfig, elementName);
                    return defaultConfig;
                }

                XDocument doc = XDocument.Load(_filePath);
                XElement rootElement = doc.Element(_rootElementName).Element(elementName);

                // 反序列化 XML 元素为配置类对象
                var serializer = new XmlSerializer(typeof(T));
                using var reader = rootElement.CreateReader();
                return (T)serializer.Deserialize(reader);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
