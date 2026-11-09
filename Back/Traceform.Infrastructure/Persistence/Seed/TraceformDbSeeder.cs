using Microsoft.EntityFrameworkCore;
using Traceform.Domain.Entities;
using Traceform.Domain.Enums;
using Traceform.Infrastructure.Persistence.Context;

namespace Traceform.Infrastructure.Persistence.Seed;

public static class TraceformDbSeeder
{
    public static async Task SeedAsync(
        TraceformDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!await context.Services.AnyAsync())
        {
            var services = new[]
            {
                Service.Create(
                    "Emergency Electrician Manchester",
                    "emergency-electrician-manchester",
                    "24/7 emergency electrical assistance across Manchester.",
                    "Fast and reliable emergency electrical services for faults, outages, tripping electrics and other urgent electrical problems across Manchester and Greater Manchester.",
                    null,
                    true,
                    1),

                Service.Create(
                    "Electrical Fault Finding",
                    "electrical-fault-finding",
                    "Professional electrical fault finding and diagnosis.",
                    "We identify electrical faults quickly and safely to help restore your electrical system and prevent further problems.",
                    null,
                    true,
                    2),

                Service.Create(
                    "Power Outages",
                    "power-outages",
                    "Emergency support when your power goes down.",
                    "Rapid electrical assistance for unexpected power outages and electrical failures across Manchester and surrounding areas.",
                    null,
                    true,
                    3),

                Service.Create(
                    "Tripping Electrics",
                    "tripping-electrics",
                    "Help with repeatedly tripping circuits and electrics.",
                    "We investigate recurring electrical trips and identify the underlying fault so your electrical system can operate safely again.",
                    null,
                    true,
                    4),

                Service.Create(
                    "Fuse Box & Consumer Unit Repairs",
                    "fuse-box-consumer-unit-repairs",
                    "Professional fuse box and consumer unit repairs.",
                    "Expert assistance with faulty fuse boxes, consumer units and related electrical issues.",
                    null,
                    true,
                    5),

                Service.Create(
                    "Faulty & Sparking Sockets",
                    "faulty-sparking-sockets",
                    "Emergency assistance for faulty or sparking sockets.",
                    "Unsafe, damaged or sparking sockets can present a serious electrical risk. We provide prompt fault diagnosis and repair.",
                    null,
                    true,
                    6),

                Service.Create(
                    "Lighting Faults",
                    "lighting-faults",
                    "Fast diagnosis and repair of lighting problems.",
                    "We diagnose and repair electrical lighting faults in homes and commercial properties.",
                    null,
                    true,
                    7),

                Service.Create(
                    "Commercial Emergency Electrician",
                    "commercial-emergency-electrician",
                    "24/7 emergency electrical support for businesses.",
                    "Professional emergency electrical assistance for commercial properties across Manchester and Greater Manchester.",
                    null,
                    true,
                    8)
            };

            await context.Services.AddRangeAsync(services);
        }

        if (!await context.Areas.AnyAsync())
        {
            var areas = new[]
            {
                Area.Create(
                    "Manchester",
                    "manchester",
                    "24/7 emergency electrical services across Manchester.",
                    "TRACEFORM provides rapid emergency electrical assistance throughout Manchester for residential and commercial customers.",
                    1),

                Area.Create(
                    "Salford",
                    "salford",
                    "Emergency electrician services across Salford.",
                    "Fast and reliable emergency electrical support for customers throughout Salford and surrounding areas.",
                    2),

                Area.Create(
                    "Stockport",
                    "stockport",
                    "Professional emergency electrical services in Stockport.",
                    "TRACEFORM provides emergency electrical assistance across Stockport for urgent electrical faults and failures.",
                    3),

                Area.Create(
                    "Trafford",
                    "trafford",
                    "24/7 electrical emergency support across Trafford.",
                    "Professional emergency electrical services for homes and businesses throughout Trafford.",
                    4),

                Area.Create(
                    "Bolton",
                    "bolton",
                    "Emergency electrical assistance across Bolton.",
                    "Rapid response electrical services for urgent faults and electrical problems throughout Bolton.",
                    5),

                Area.Create(
                    "Oldham",
                    "oldham",
                    "Emergency electrician services across Oldham.",
                    "TRACEFORM provides professional emergency electrical assistance across Oldham and surrounding areas.",
                    6)
            };

            await context.Areas.AddRangeAsync(areas);
        }

        if (!await context.Reviews.AnyAsync())
        {
            var reviews = new[]
            {
                Review.Create(
                    "James Wilson",
                    "Excellent response time and very professional service. The electrical fault was diagnosed quickly and resolved safely.",
                    5),

                Review.Create(
                    "Sarah Thompson",
                    "Called late at night with an electrical emergency and received a fast response. Very professional from start to finish.",
                    5),

                Review.Create(
                    "Daniel Roberts",
                    "Reliable service, clear communication and the issue was fixed quickly. Would definitely recommend.",
                    5)
            };

            foreach (var review in reviews)
            {
                review.Publish();
            }

            await context.Reviews.AddRangeAsync(reviews);
        }

        if (!await context.FAQs.AnyAsync())
        {
            var faqs = new[]
            {
                FAQ.Create(
                    "Are you available 24/7?",
                    "Yes. TRACEFORM provides emergency electrical assistance 24 hours a day, 7 days a week across Manchester and Greater Manchester.",
                    1),

                FAQ.Create(
                    "What electrical emergencies do you deal with?",
                    "We deal with urgent electrical problems including power outages, tripping electrics, sparking sockets, lighting faults, fuse box issues and other electrical failures.",
                    2),

                FAQ.Create(
                    "Do you cover areas outside Manchester?",
                    "Yes. We cover Manchester and a range of locations across Greater Manchester. Contact us to confirm coverage for your area.",
                    3),

                FAQ.Create(
                    "How quickly can an emergency electrician arrive?",
                    "Response times depend on your location, traffic and current demand. Contact us as soon as possible so we can assess your emergency and arrange assistance.",
                    4),

                FAQ.Create(
                    "Do you provide commercial emergency electrical services?",
                    "Yes. We provide emergency electrical support for commercial properties and businesses across Manchester and Greater Manchester.",
                    5)
            };

            await context.FAQs.AddRangeAsync(faqs);
        }

        if (!await context.Projects.AnyAsync())
        {
            var projects = new[]
            {
                Project.Create(
                    "Emergency Power Restoration",
                    "Emergency electrical fault diagnosis and power restoration for a residential property in Manchester.",
                    null,
                    "Manchester"),

                Project.Create(
                    "Commercial Electrical Fault",
                    "Urgent electrical fault investigation and repair for a commercial property.",
                    null,
                    "Salford"),

                Project.Create(
                    "Consumer Unit Repair",
                    "Emergency consumer unit repair and electrical fault resolution.",
                    null,
                    "Stockport")
            };

            await context.Projects.AddRangeAsync(projects);
        }

        await context.SaveChangesAsync();
    }
}
