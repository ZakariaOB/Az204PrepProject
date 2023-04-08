- Dynamic Site Acceleration (DSA) is a content delivery technique that uses advanced caching algorithms and real-time network optimization to accelerate the delivery of dynamic, personalized web content. Unlike traditional content delivery networks (CDNs), which are optimized for caching static content, DSA is designed to accelerate dynamic web pages that require frequent updates and personalized content based on user interactions.
DSA works by analyzing user requests and dynamically optimizing the delivery of content based on factors such as geographic location, network conditions, and server load. It uses a combination of caching, compression, and network optimization techniques to reduce page load times and improve overall web performance.
    Some of the key features of DSA include :
    - Real-time optimization: DSA uses real-time data to optimize content delivery based on user behavior and network conditions.
    - Dynamic caching: DSA uses advanced caching algorithms to cache frequently accessed content and reduce the load on origin servers.
    - Image optimization: DSA automatically optimizes images to reduce file size and improve page load  times.
    - Intelligent routing: DSA routes requests to the most optimal server based on geography, network    conditions, and other factors.
    - HTTPS support: DSA supports HTTPS encryption to ensure that content is delivered securely.
    - DSA is particularly useful for websites that generate dynamic content, such as e-commerce sites,   social media platforms, and news sites. By accelerating the delivery of dynamic content, DSA can   improve user experience, increase engagement, and reduce bounce rates.



- Choosing between **Akamai** and **Microsoft** CDN profiles depends on several factors such as your specific needs, budget, technical requirements, and business objectives. Here are some situations when you might consider choosing Akamai over Microsoft or vice versa:

    Choose Akamai if:
    - You need a global CDN with a larger network reach: Akamai has a larger global network of servers than Microsoft, making it a good choice if you have a global audience and need to deliver content to multiple regions around the world.
    - You require a high level of customization and flexibility: Akamai offers a greater degree of customization and configuration options for CDN settings, making it a good choice if you have complex delivery requirements or need to fine-tune your CDN settings based on specific needs.
    - You have high-traffic and **high-performance requirements**: Akamai's CDN infrastructure is designed to handle high volumes of traffic and provide optimal performance for high-demand websites and applications.

    Choose Microsoft if:
    - You are already using Azure cloud services: Microsoft's Azure CDN is tightly integrated with other Azure cloud services, making it an easy choice if you are already using Azure and want a tightly integrated CDN solution.
    - You need cost-effective pricing: Microsoft's pricing model for Azure CDN is typically more cost-effective than Akamai's pricing model, making it a good choice if you need to keep costs low.
    - You need advanced security and compliance features: Microsoft Azure CDN offers advanced security and compliance features, such as DDoS protection, Web Application Firewall (WAF), and PCI compliance, making it a good choice if you have strict security and compliance requirements.

    In general, if you have a global audience with high traffic and performance requirements, and you need a high degree of customization and configuration options, Akamai may be the better choice. If you are already using Azure cloud services, need cost-effective pricing, and require advanced security and compliance features, Microsoft may be the better choice.



- **Azure Backup**
The VM is critical and has not been backed up in the past. The VM must enable a quick restore from a 7-day snapshot to include in-place restore of disks in case of failure.
In-Place restore of disks in IaaS VMs is a feature of Azure Backup.
Performance: Accelerated Networking
Scenario: The VM shows high network latency, jitter, and high CPU utilization.

- **Accelerated networking**
The VM shows high network latency, jitter, and high CPU utilization.
Accelerated networking enables single root I/O virtualization (SR-IOV) to a VM, greatly improving its networking performance. This high-performance path bypasses the host from the datapath, reducing latency, jitter, and CPU utilization, for use with the most demanding network workloads on supported VM types.
Reference:
https://azure.microsoft.com/en-us/blog/an-easy-way-to-bring-back-your-azure-vm-with-in-place-restore/


- Shipping Function app: Implement secure function endpoints by using app-level security and include Azure Active Directory (Azure AD).
  - Authorization level : Function
  - User claims : JSON based Token (JWT) Azure AD uses JSON based tokens (JWTs) that contain claims
  - Trigger type : HTTP
    How a web app delegates sign-in to Azure AD and obtains a token
    User authentication happens via the browser. The OpenID protocol uses standard HTTP protocol messages.
