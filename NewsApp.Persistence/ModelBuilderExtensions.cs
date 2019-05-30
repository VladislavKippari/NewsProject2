using Microsoft.EntityFrameworkCore;
using NewsApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsApp.Persistence
{
   public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new { RoleId = 1, RoleName = "Admin" },
                new { RoleId = 2, RoleName = "User" },
            new { RoleId = 3, RoleName = "Journalist" });
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 1,
                FirstName = "Petr",
                LastName = "Petrov",
                Email = "admin@test.com",
                Password = PasswordGenerate.HashPassword("Admin-12345"),
                RoleId = 1
            });
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 2,
                FirstName = "Anna",
                LastName = "Petrova",
                Email = "user1@test.com",
                Password = PasswordGenerate.HashPassword("User1-12345"),
                RoleId = 2
            });
            modelBuilder.Entity<User>().HasData(new
            {
                UserId = 3,
                FirstName = "Jour",
                LastName = "Journalist",
                Email = "journalist1@test.com",
                Password = PasswordGenerate.HashPassword("Journalist1-12345"),
                RoleId = 3
            });
            modelBuilder.Entity<Category>().HasData(
                new { CategoryId = 1, Name = "Technology"},
                new { CategoryId = 2, Name = "Chemistry"});
            modelBuilder.Entity<Article>().HasData(new
                {
                    ArticleId = 1,
                    Title = "A new optical atomic clock’s heart is as small as a coffee bean",
                    ArticleText = "Portable atomic clocks are on their way to an upgrade. Today’s small, battery - operated atomic clocks track time by counting oscillations of light absorbed by cesium atoms(SN: 9 / 4 / 04, p. 50).That light oscillates billions of times per second.Now, a miniature version of a type of atomic clock called an optical clock uses light tuned to rubidium atoms, and beats trillions of times per second(SN Online: 5 / 20 / 19).Dividing time into such short intervals allows this atomic timepiece to keep time much more reliably than other clocks, researchers report May 20 in Optica.Ordinarily, the chamber of atoms at the heart of an optical clock might be a meter across.The new mini optical clock uses an atom chamber a mere 3 millimeters across mounted on a silicon chip. “I was very surprised they were able to make an optical clock this size,” says Silvio Koller, who worked on optical clocks at the National Metrology Institute of Germany in Braunschweig. A new generation of small - scale optical clocks could better coordinate the flow of data through telecommunication networks, or sync up far - flung telescopes to make astronomical observations(SN: 4 / 27 / 19, p. 7). The “pendulum” inside the new optical clock is a laser tuned to about 385.285 terahertz — that is, its light undulates 385.285 trillion times per second.To ensure that the laser’s oscillations don’t fall out of rhythm, half of the beam feeds into the tiny chamber of rubidium atoms, which absorb light at precisely this frequency.Monitoring whether the rubidium atoms are absorbing light tells the laser whether it needs to dial its frequency slightly up or down to keep time more precisely. Modern electronics can’t actually count the individual 385 - terahertz ticks of this laser because they’re too fast, says study coauthor Zachary Newman, a physicist at the National Institute of Standards and Technology in Boulder, Colo. So the optical clock uses two components called frequency combs, also mounted on tiny chips, to translate the laser’s rapid - fire beats into slower, countable ticks.This works similar to the way a set of gears can translate the rapid spin of a small disk into the slower rotation of a larger disk(SN: 10 / 22 / 11, p. 22). The optical clock ultimately produced ticks paced at 22 gigahertz — about twice as fast as those of cesium - based metronomes.But because the optical clock’s gigahertz ticks are based on the much shorter, terahertz beats, they’re far more precise than the gigahertz ticks of cesium clocks.The duration of each second counted out by the chip - scale optical clock matched every other, down to about five trillionths of a second. That’s roughly 50 times better than the current cesium - based chip - scale clocks, says study coauthor Matthew Hummon, also a physicist at NIST in Boulder. Even though the new optical clock is pint - size compared with its predecessors, it isn’t a pocket watch yet.The chip - scale atom chamber and frequency combs are hooked up to supporting electronics that fill two tables. “Eventually we’d like to get this technology to be truly handheld and battery powered,” Hummon says.",
                    Image = "052419_mt_atomicclock_feat.jpg",
                    JournalistId = 1,
                    CategoryId = 1
                });
            modelBuilder.Entity<Article>().HasData(new
            {
                ArticleId = 2,
                Title = "A new AI training program helps robots own their ignorance",
                ArticleText = "HONOLULU — A new training scheme could remind artificial intelligence programs that they aren’t know-it-alls. AI programs that run robots, self-driving cars and other autonomous machines often train in simulated environments before making real-world debuts (SN: 12/8/18, p. 14). But situations that an AI doesn’t encounter in virtual reality can become blind spots in its real-life decision making. For instance, a delivery bot trained in a virtual cityscape with no emergency vehicles may not know that it should pause before entering a crosswalk if it hears sirens. To create machines that err on the side of caution, computer scientist Ramya Ramakrishnan of MIT and colleagues developed a post-simulation training program in which a human demonstrator helps the AI identify gaps in its education. “This allows the [AI] to safely act in the real world,” says Ramakrishnan, whose work is being presented January 31 at the AAAI Conference on Artificial Intelligence. Engineers could also use information on AI blind spots to design better simulations in the future. During its probationary period, the AI takes note of environmental factors influencing the human’s actions that it does not recognize from its simulation. When the human does something the AI doesn’t expect — like hesitating to enter a crosswalk despite having the right-of-way — the AI scans its surroundings for previously unknown elements, such as sirens. If the AI detects any of these features, it assumes the human is following some safety protocol it didn’t learn in the virtual world and that it should defer to the human’s judgment in these types of situations. Ramakrishnan and colleagues have tested this setup by first training AI programs in simplistic simulations and then letting them learn their blind spots from human characters in more realistic, but still virtual, worlds. The researchers now need to test the system in the real world.",
                Image = "012919_MT_AI-blind-spots_feat.jpg",
                JournalistId = 1,
                CategoryId = 1
            });
            modelBuilder.Entity<Article>().HasData(new
            {
                ArticleId = 3,
                Title = "Sweaty, vinegary and sweet odors mingle to make dark chocolate’s smell",
                ArticleText = "Scientists have sniffed out the chemicals that give some dark chocolates their smell. The compounds that mingle to make the candy’s aroma include pleasant-smelling ones such as vanillin, which gives vanilla its smell, and flowery linalool. But other molecules produce smoky or vinegary odors and even one that smells like sweat, researchers report online May 8 in the Journal of Agricultural and Food Chemistry. “These single odorants usually never have the typical smell of the food itself,” says Michael Granvogl, a food chemist at the University of Hohenheim in Stuttgart, Germany. Instead, in any given food, the scent depends on which molecules are present and at what level, he says. Granvogl and his colleague Carolin Seyfried of the Technical University of Munich picked two particularly aromatic chocolate bars having at least 90 percent cocoa content from a grocery store. The pair crushed up each of the treats and extracted their volatile compounds, those that vaporize easily and can waft up to our noses to be smelled. Of the roughly 70 aroma-producing volatile chemicals detected, between 28 and 30 occurred in each bar at high enough levels for humans to smell. By combining these compounds at roughly the same concentrations as in the original chocolate bars, the scientists re-created each bar’s aroma. A panel of more than 20 people with trained noses sniffed the concoctions and found that they smelled similar to the real deal. The study is the first to reconstruct dark chocolate’s smell from odor compounds measured using state-of-the-art techniques, the researchers say.",
                Image = "052219_cw_chocolate_feat.jpg",
                JournalistId = 3,
                CategoryId = 3
            });
            modelBuilder.Entity<Comment>().HasData(new
            {
                CommentId = 1,
                CommentText = "Testing comment section",
                UserId = 1,
                ArticleId = 1
            });
            modelBuilder.Entity<Comment>().HasData(new
            {
                CommentId = 2,
                CommentText = "Oppa Gangnam Style!",
                UserId = 1,
                ArticleId = 3
            });
            modelBuilder.Entity<Comment>().HasData(new
            {
                CommentId = 3,
                CommentText = "Choice of the professional",
                UserId = 1,
                ArticleId = 3
            });
            modelBuilder.Entity<Comment>().HasData(new
            {
                CommentId = 4,
                CommentText = "Oops",
                UserId = 1,
                ArticleId = 1
            });
        }
    }
}
